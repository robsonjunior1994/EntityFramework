namespace crudSimples.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public IList<Produto> Produtos { get; set; }
    }
}
