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

const BarChartComponent = ({ data, options }) => {
  const [chartReference, setChartReference] = useState(null);

  useEffect(() => {
    const chart = new Bar({
      data,
      options,
      mounted: () => {
        setChartReference(chart);
      },
    });

    return () => {
      chart.destroy();
    };
  }, [data, options]);

  return (
    <div className="test">
      <Bar ref={chartReference} />
    </div>
  );
};

export default BarChartComponent;
