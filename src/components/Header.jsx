import React from 'react';
import img from "../../public/images/UNIVERSAL.png";
import AnimatedNumber from './AnimatedNumber';

export default function Header({
  month,
  setMonth,
  openOrders = 0,
  totalValueOpenOrders = 0.00,
  totalOpenOrdersMonth = 0,
  totalClosedOrdersMonth = 0,
  totalMonthlyRevenueMonth = 0.00,
  totalCommissionsMonth = 0.00,
  totalProductsSoldMonth = 0,
}) {
  return (
    <header className="bg-red-600 text-white py-4">
      <div className="container mx-auto flex flex-col items-center space-y-4">
        <div className="flex w-full justify-between items-center">
          <div>
            <label htmlFor="month" className="mr-2 font-semibold">Mês:</label>
            <select
              id="month"
              value={Number(month)}
              onChange={(e) => setMonth((month) => Number(e.target.value))}
              className="font-semibold text-gray-900 px-2 py-1 rounded"
            >
              {Array.from({ length: 12 }, (_, i) => (
                <option key={i + 1} value={i + 1}>
                  {new Date(0, i).toLocaleString('pt-BR', { month: 'long' })}
                </option>
              ))}
            </select>
          </div>
          <div className='rounded-2xl bg-white w-80 flex justify-center'>
            <img src={ img } alt="Logo" className="h-16" />
          </div>
        </div>
        <div className="font-semibold flex space-x-4 text-center">
          <div>Pedidos Abertos:<br /><p className="text-2xl">
            <AnimatedNumber number={ openOrders } />
            </p></div>
          <div>Valor Total Pedidos Abertos:<br /><p className="text-2xl">
            R$: <AnimatedNumber number={ totalValueOpenOrders } decimals={2} />
            </p></div>
          <div>Pedidos Abertos/Mês:<br /><p className="text-2xl">
            <AnimatedNumber number={ totalOpenOrdersMonth } />
            </p></div>
          <div>Pedidos Fechados/Mês:<br /><p className="text-2xl">
            <AnimatedNumber number={ totalClosedOrdersMonth } />
            </p></div>
          <div>Total Faturamento/Mês:<br /><p className="text-2xl">
            R$: <AnimatedNumber number={ totalMonthlyRevenueMonth } decimals={2} />
            </p></div>
          <div>Total Comissões/Mês:<br /><p className="text-2xl">
            R$:<AnimatedNumber number={ totalCommissionsMonth } decimals={2} />
            </p></div>
          <div>Produtos Vendidos/Mês:<br /><p className="text-2xl">
            <AnimatedNumber number={ totalProductsSoldMonth } />
            </p></div>
        </div>
      </div>
    </header>
  );
}
