using crudSimples.DTO;
using crudSimples.Infrastruture;
using crudSimples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudSimples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        //Esse é um CRUD que representa um relacinamento N:N
        Context context = new Context();

        [Route("All")]
        [HttpGet]
        public IActionResult Get()
        {
            IList<Promocao> promocaes = context
                                        .Promocao
                                        .Include(p => p.Produtos)
                                        .ToList();
            return Ok(promocaes);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Promocao promocao = context.Promocao
                                    .Include(c => c.Produtos)
                                    .FirstOrDefault(c => c.Id == id);
            return Ok(promocao);
        }

        [HttpPost]
        public IActionResult Post(PromocaoDTO promocaoDTO)
        {
            Promocao promocao = new Promocao();
            promocao.Name = promocaoDTO.Name;
            promocao.Inicio = promocaoDTO.Inicio;
            promocao.Fim = promocaoDTO.Fim;

            foreach (var produtoDTO in promocaoDTO.Produtos)
            {
                Produto produto = new Produto();
                produto.Promocao = new List<Promocao>();
                promocao.Produtos = new List<Produto>();

                produto.Nome = produtoDTO.Nome;
                produto.Preco = produtoDTO.Preco;
                produto.Promocao.Add(promocao);
                promocao.Produtos.Add(produto);
            }

            context.Promocao.Add(promocao);

            foreach (var produto in promocao.Produtos)
            {
                if (produto.Id > 0)
                {
                    var produtoBanco = context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
                    produtoBanco.Preco = produto.Preco;
                    produtoBanco.Nome = produto.Nome;
                    context.Produtos.Update(produtoBanco);
                }
            }

            context.SaveChanges();
            return Ok(promocao);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Promocao promocao = context.Promocao.Include(c => c.Produtos).FirstOrDefault(c => c.Id == id);
            context.Promocao.Remove(promocao);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Cliente compraRequest)
        {
            Promocao promocao = context.Promocao.Include(c => c.Produtos).FirstOrDefault(c => c.Id == compraRequest.Id);
            //atualizar
            context.SaveChanges();

            return Ok();
        }
    }
}
