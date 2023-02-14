using crudSimples.Infrastruture;
using crudSimples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudSimples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        //Esse é um CRUD que representa um relacinamento 1:N
        Context context = new Context();

        [Route("All")]
        [HttpGet]
        public IActionResult Get()
        {
            IList<Compra> compras = context
                                        .Compras
                                        .Include(c => c.Produtos)
                                        .ToList();
            return Ok(compras);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Compra compra = context.Compras
                                    .Include(c => c.Produtos)
                                    .FirstOrDefault(c => c.Id == id);
            return Ok(compra);
        }

        [HttpPost]
        public IActionResult Post(Compra compra)
        {
            context.Compras.Add(compra);

            foreach(var produto in compra.Produtos) 
            { 
                if(produto.Id > 0)
                {
                    var produtoBanco = context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
                    produtoBanco.Preco = produto.Preco;
                    produtoBanco.Nome = produto.Nome;
                    context.Produtos.Update(produtoBanco);
                }
            }

            context.SaveChanges();
            return Ok(compra);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Compra compra = context.Compras.Include(c => c.Produtos).FirstOrDefault(c => c.Id == id);
            context.Compras.Remove(compra);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Cliente compraRequest)
        {
            Compra compra = context.Compras.Include(c => c.Produtos).FirstOrDefault(c => c.Id == compraRequest.Id);
            //atualizar
            context.SaveChanges();

            return Ok();
        }
    }
}
