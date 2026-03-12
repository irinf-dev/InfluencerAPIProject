import React from "react";
import { Bar, Pie } from "react-chartjs-2";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  ArcElement,
  Title,
  Tooltip,
  Legend,
} from "chart.js";

ChartJS.register(CategoryScale, LinearScale, BarElement, ArcElement, Title, Tooltip, Legend);

const AnalyticsPage = () => {
  const barData = {
    labels: ["Instagram", "YouTube", "TikTok"],
    datasets: [
      {
        label: "Followers",
        data: [27000, 50000, 8000],
        backgroundColor: ["#E1306C", "#FF0000", "#000000"],
      },
    ],
  };

  const pieData = {
    labels: ["Instagram", "YouTube", "TikTok"],
    datasets: [
      {
        label: "Influencers",
        data: [2, 1, 1],
        backgroundColor: ["#E1306C", "#FF0000", "#000000"],
      },
    ],
  };

  return (
    <div className="p-8">
      <h1 className="text-2xl font-bold mb-6">Analytics</h1>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
        <div className="bg-white dark:bg-gray-800 p-6 rounded shadow">
          <Bar data={barData} />
        </div>
        <div className="bg-white dark:bg-gray-800 p-6 rounded shadow">
          <Pie data={pieData} />
        </div>
      </div>
    </div>
  );
};

export default AnalyticsPage;
