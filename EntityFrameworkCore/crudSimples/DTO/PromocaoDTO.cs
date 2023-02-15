using crudSimples.Models;

namespace crudSimples.DTO
{
    public class PromocaoDTO
    {
        public string Name { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public IList<ProdutoDTO> Produtos { get; set; }
    }
}
