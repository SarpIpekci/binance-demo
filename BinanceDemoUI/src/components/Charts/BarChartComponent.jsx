import React, { useState, useEffect, useRef } from "react";
import { Bar } from "react-chartjs-2";
import { HubConnectionBuilder } from "@microsoft/signalr";
import Accordion from "react-bootstrap/Accordion";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import "../Charts/BarChartComponent.css";
import InputCardComponent from "../InputCard/InputCardComponent";
import { FaMoneyBill } from "react-icons/fa";
import { MdOutlineTableView } from "react-icons/md";
import { MdSell } from "react-icons/md";
import {
  Chart as ChartJS,
  BarElement,
  CategoryScale,
  LinearScale,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(BarElement, CategoryScale, LinearScale, Tooltip, Legend);

const BarChartComponent = ({ setUserData }) => {
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
    let datasetColors = [];
    const newData = {
      labels: symbols,
      datasets: [
        {
          data: prices,
          backgroundColor: datasetColors,
        },
      ],
    };

    const chart = chartReference.current;
    setData(newData);

    if (chart.data.datasets.length === 0) {
      chart.update();
    } else {
      prices.forEach((price, index) => {
        let previousPrice = chart.data.datasets[0].data[index];
        if (price > previousPrice) {
          datasetColors.push("#267365");
        } else if (price < previousPrice) {
          datasetColors.push("#F23030");
        } else {
          datasetColors.push(chart.data.datasets[0].backgroundColor[index]);
        }
      });
      chart.data.datasets[0].data = prices;
      chart.data.datasets[0].backgroundColor = datasetColors;
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
        <Col
          ms={4}
          className="d-flex justify-content-center align-items-center"
        >
          <InputCardComponent
            title={false}
            text={false}
            titleValue={""}
            textValue={""}
            columns={[
              { text: <FaMoneyBill className="my-icon-buy" />, md: 6 },
              { text: "Buy New Coins", md: 6 },
            ]}
          />
        </Col>

        <Col
          ms={4}
          className="d-flex justify-content-center align-items-center"
        >
          <InputCardComponent
            title={false}
            text={false}
            titleValue={""}
            textValue={""}
            columns={[
              { text: <MdSell className="my-icon-sell" />, md: 6 },
              { text: "Sell The Coins", md: 6 },
            ]}
          />
        </Col>

        <Col
          ms={4}
          className="d-flex justify-content-center align-items-center"
        >
          <InputCardComponent
            title={false}
            text={false}
            titleValue={""}
            textValue={""}
            columns={[
              { text: <MdOutlineTableView className="my-icon-table" />, md: 6 },
              { text: "Show All Trades", md: 6 },
            ]}
          />
        </Col>

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
