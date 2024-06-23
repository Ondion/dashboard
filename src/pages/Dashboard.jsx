import React, { useState, useEffect } from 'react';
import Header from '../components/Header';
import OrderCard from '../components/OrderCard';
import PieChart from '../components/PieChart';
import Footer from '../components/Footer';
import Swal from 'sweetalert2';

export default function Dashboard() {
  const [month, setMonth] = useState(new Date().getMonth() + 1);
  const [quantityOrders, setQuantityOrders] = useState(3);
  const [buttonState, setButtonState] = useState(0);

  const [data, setData] = useState({
    totalOpenOrdersMonth: 1,
    totalClosedOrdersMonth: 1,
    orders: [0],
  });

  useEffect(() => {
    Swal.mixin({
      toast: true,
      showConfirmButton: false,
      timer: 1000,
      timerProgressBar: true,
    }).fire({ icon: "success", title: "... Carregando" });


    const fetchData = async () => {
      try {
        const metricsPromise = fetch(`http://localhost:5042/order?time=2024-${month}`);
        const ordersPromise = fetch(`http://localhost:5042/order/${quantityOrders}`);
        const result = await Promise.all([metricsPromise, ordersPromise]);
        const metrics = await result[0].json();
        const orders = await result[1].json();
        if (metrics || orders) setData((data) => data = { ...metrics, orders });
      } catch (error) {
      }
    };

    fetchData();
    const interval = setInterval(fetchData, 10000);

    return () => clearInterval(interval);
  }, [month, quantityOrders]);

  function HandleButton({target})
  {
    setButtonState(buttonState === 2 ? 0 : buttonState + 1);
    if(buttonState === 1){
      target.innerText = "Abertos / Fechados"
      target.className = "border-4 border-red-500 text-black font-bold p-2 rounded-lg";
    }
    else if(buttonState === 2) {
      target.innerText = "Somente Abertos"
      target.className = "border-4 border-yellow-300 text-black font-bold p-2 rounded-lg";
    }
    else {
      target.innerText = "Somente Fechados"
      target.className = "border-4 border-green-400 text-black font-bold p-2 rounded-lg";
    }
  }

  return (
    <div className="flex flex-col min-h-screen">
      <Header month={month} setMonth={setMonth} {...data} />
      <main className="flex flex-1 container mx-auto py-8">
        <div className="w-1/2 pr-4 flex flex-wrap">
        <div className='mx-4 flex flex-col'>
          <label htmlFor="last-orders" className="text-center font-semibold text-gray-700">Buscar Últimos Pedidos:</label>
          <input
          className='w-20'
            type="number"
            id="last-orders"
            name="last-orders"
            step="1"
            value={Number(quantityOrders)}
            onChange={(e) => setQuantityOrders((quantityOrders) => Number(e.target.value))}
          />
        </div>


        <div>
          <button
          className='border-4 border-yellow-300 text-black font-bold p-2 rounded-lg'
          onClick={(e) => HandleButton(e)}
          value={ buttonState }
          >
            Somente Abertos
          </button>
        </div>   
    
         
          {data.orders.filter(e => {
            if(buttonState == 1) return e.statusPedido === "aberto"
            else if(buttonState == 2) return e.statusPedido === "fechado"
            else return e.statusPedido
          }).map((order, i) => (<OrderCard key={i} {...order} />))}
        </div>
        <div className="w-1/2 pl-4">
          <PieChart {...data} />
        </div>
      </main>
      <Footer />
    </div>
  );
}
