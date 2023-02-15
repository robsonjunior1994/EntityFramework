namespace crudSimples.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public IList<Promocao> Promocao { get;set; }
    }
}
