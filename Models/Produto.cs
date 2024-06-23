namespace FullApp.Models
{
    using System.ComponentModel.DataAnnotations;

public class Produto
{
    [Key]
    public int ID { get; set; }
    public string? NomeProduto { get; set; }
    public decimal ValorUnitario { get; set; }
    public string? StatusProduto { get; set; }
    
    public virtual ICollection<PedidoProduto>? PedidoProduto { get; set; }
}

}
