using crudSimples.Infrastruture;
using crudSimples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudSimples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //Esse é um CRUD que representa um relacinamento 1:N
        Context context = new Context();

        [Route("All")]
        [HttpGet]
        public IActionResult Get()
        {
            IList<Produto> produtos = context
                                        .Produtos
                                        .ToList();
            return Ok(produtos);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Produto produto = context
                                .Produtos
                                .FirstOrDefault(c => c.Id == id);
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
            return Ok(produto);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Produto produto = context.Produtos.FirstOrDefault(c => c.Id == id);
            context.Produtos.Remove(produto);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Cliente produtoRequest)
        {
            Produto produto = context.Produtos.FirstOrDefault(c => c.Id == produtoRequest.Id);
            //atualizar
            context.SaveChanges();

            return Ok();
        }
    }
}
