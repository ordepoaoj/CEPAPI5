using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            if (cep.Length == 9)
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
