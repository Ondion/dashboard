namespace FullApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PedidoProduto
    {
        [Key]
        public int ID { get; set; }
        public int PedidoID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        public virtual Pedido? Pedido { get; set; }
        public virtual Produto? Produto { get; set; }
    }
}
