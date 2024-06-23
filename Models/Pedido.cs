namespace FullApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Pedido
    {
        [Key]
        public int ID { get; set; }
        public string? NomeCliente { get; set; }
        public string? NomeVendedor { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal TotalComissao { get; set; }
        public DateTime DataPedido { get; set; }
        public string StatusPedido { get; set; } = "aberto";
        public virtual ICollection<PedidoProduto>? PedidoProduto { get; set; } = null;

    }

}
