import React, { useState, useEffect, useRef } from "react";
import { Bar } from "react-chartjs-2";
import { HubConnectionBuilder } from "@microsoft/signalr";
import Accordion from "react-bootstrap/Accordion";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../Charts/BarChartComponent.css";
import {
  Chart as ChartJS,
  BarElement,
  CategoryScale,
  LinearScale,
  Tooltip,
  Legend,
} from "chart.js";
import TradeInputComponent from "../TradeInputs/TradeInputComponent";

ChartJS.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend);

const BarChartComponent = ({ setUserData, userDataValue }) => {
  const chartReference = useRef(null);
  const [data, setData] = useState({
    labels: [],
    datasets: [],
  });

  useEffect(() => {
    setUserData(localStorage.getItem("userData"));

    const connection = new HubConnectionBuilder()
      .withUrl("https://localhost:7159/BinanceHub", {
        withCredentials: true,
      })
      .build();

    connection
      .start()
      .then(() => {
        connection.invoke("GetInitialData").then((data) => {
          updateChart(data);
        });
      })
      .catch((error) => {
        console.error(error);
      });

    connection.on("UpdateChart", (updatedValue) => {
      updateChart(updatedValue);
    });
  }, [setUserData]);

  const updateChart = (updatedData) => {
    const parsedData = JSON.parse(updatedData);
    const symbols = parsedData.map((entry) => entry.symbol);
    const prices = parsedData.map((entry) => entry.price);

    const chart = chartReference.current;

    const newBackgroundColors = prices.map((price, index) => {
      if (
        !chart.data.datasets[0] ||
        chart.data.datasets[0].data.length <= index
      ) {
        return "#21618C";
      }
      const previousPrice = chart.data.datasets[0].data[index];
      if (price > previousPrice) {
        return "#267365";
      } else if (price < previousPrice) {
        return "#F23030";
      } else {
        return chart.data.datasets[0].backgroundColor[index];
      }
    });

    if (chart.data.datasets.length > 0) {
      chart.data.labels = symbols;
      chart.data.datasets[0].data = prices;
      chart.data.datasets[0].backgroundColor = newBackgroundColors;
    } else {
      chart.data = {
        labels: symbols,
        datasets: [
          {
            data: prices,
            backgroundColor: newBackgroundColors,
            label: "Coin Prices",
          },
        ],
      };
    }

    chart.update();
  };

  const options = {
    responsive: true,
    maintainAspectRatio: false,
    scales: {
      y: {
        beginAtZero: true,
        ticks: {
          stepSize: 0.0001,
        },
      },
    },
  };

  return (
    <div className="container-sm">
      <Row>
        {userDataValue && (
          <>
            <TradeInputComponent />
          </>
        )}
        <Col md={12}>
          <Accordion className="no-arrow mt-5">
            <Accordion.Item>
              <Accordion.Header className="custom-header">
                Real Time Coin Tracking
              </Accordion.Header>
              <Accordion.Body>
                <div className="chartContainer">
                  <Bar ref={chartReference} data={data} options={options} />
                </div>
              </Accordion.Body>
            </Accordion.Item>
          </Accordion>
        </Col>
      </Row>
    </div>
  );
};

export default BarChartComponent;
