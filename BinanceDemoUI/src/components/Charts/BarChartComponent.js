import React, { useState, useEffect, useRef } from "react";
import { Bar } from "react-chartjs-2";
import { HubConnectionBuilder } from "@microsoft/signalr";
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
  }, []);

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
          datasetColors.push("green");
        } else if (price < previousPrice) {
          datasetColors.push("red");
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
      <div className="p-5">
        <Bar ref={chartReference} data={data} options={options} />
      </div>
    </div>
  );
};

export default BarChartComponent;
