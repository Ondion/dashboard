import React from 'react';
import { Pie } from 'react-chartjs-2';
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js';

ChartJS.register(ArcElement, Tooltip, Legend);

export default function PieChart({ totalOpenOrdersMonth, totalClosedOrdersMonth }) {
  const data = {
    labels: ['Pedidos Abertos', 'Pedidos Fechados'],
    datasets: [
      {
        data: [totalOpenOrdersMonth, totalClosedOrdersMonth],
        backgroundColor: ['#ecec53', '#90ee90'],
        hoverBackgroundColor: ['#FFFF00', '#008000'],
      },
    ],
  };

  return <Pie data={data} />;
}
