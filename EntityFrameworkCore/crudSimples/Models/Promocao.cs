namespace crudSimples.Models
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public IList<Produto> Produtos { get; set; }
    }
}
