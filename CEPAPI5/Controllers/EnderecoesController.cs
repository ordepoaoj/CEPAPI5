using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CEPAPI5.Models;


namespace CEPAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly CEPContext _context;

        public EnderecosController(CEPContext context)
        {
            _context = context;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<Endereco>> GetEndereco(string cep)
        {
            
            if (cep == null)
                return Ok("O valor encaminhado é nulo, favor utilizar uma formatação valida.");

            if (cep.Length == 8)
            {
               var endereco = await _context.Enderecos.Include(e => e.Bairro).Include(e => e.Cidade).Include(e => e.Cidade.Estado).FirstOrDefaultAsync(e => e.CdPostal == cep);

                if (endereco == null)
                {
                    return NotFound("O CEP não foi localizado");
                }

                return Ok(endereco);
            }

            return Ok("O código " + cep + " Encontra-se em uma formatação invalida, deve-se ter o formato XXXXX-XXX Ex. 12345-678");
        }
    }
}
