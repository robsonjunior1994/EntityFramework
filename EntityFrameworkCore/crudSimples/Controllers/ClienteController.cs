using crudSimples.Infrastruture;
using crudSimples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudSimples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Esse é um CRUD que representa um relacinamento 1:1
        Context context = new Context();

        [Route("All")]
        [HttpGet]
        public IActionResult Get()
        {
            IList<Cliente> clientes = context
                                        .Clientes
                                        .Include(c => c.Endereco)
                                        .ToList();
            return Ok(clientes);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Cliente cliente = context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return Ok(cliente);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Cliente cliente = context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Cliente clienteRequest)
        {
            Cliente cliente = context.Clientes.Include(c => c.Endereco).FirstOrDefault(c => c.Id == clienteRequest.Id);
            //atualizar
            context.SaveChanges();

            return Ok();
        }
    }
}
