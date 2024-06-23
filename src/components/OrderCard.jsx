import React from 'react';

export default function OrderCard({
  nomeCliente = "... carregando",
  nomeVendedor = "... carregando",
  valorBruto = "... carregando",
  valorLiquido = "... carregando",
  totalComissao = "... carregando",
  dataPedido = "... carregando",
  statusPedido = "... carregando",
}) {
  return (
    <div className="bg-gray-100 p-4 rounded-lg shadow-lg overflow-hidden mb-4 mx-4 w-[80%] h-fit transition duration-500 ease-in-out transform hover:scale-105">
      <h3 className="text-red-600 text-lg font-semibold">Cliente: { nomeCliente }</h3>
      <p className="text-gray-700">Vendedor: { nomeVendedor.toUpperCase() }</p>
      <p className="text-gray-700">Valor Bruto: R$:{ Number(valorBruto).toFixed(2) }</p>
      <p className="text-gray-700">Valor Líquido: R$:{ Number(valorLiquido).toFixed(2) }</p>
      <p className="text-gray-700">Total Comissão: R$:{ Number(totalComissao).toFixed(2) }</p>
      <p className="text-gray-700">Data do Pedido: { new Date(dataPedido).toLocaleString("pt-br", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric"
      }) }</p>
      <p className={`text-gray-700 ${statusPedido === 'aberto' ? 'text-yellow-500' : 'text-green-600'}`}>
        <strong>Status:</strong> { statusPedido }
      </p>
    </div>
  );
}
