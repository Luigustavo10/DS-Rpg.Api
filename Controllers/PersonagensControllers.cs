using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSigle(int id)
        {
            try
            {
                Personagem p = await _context.Personagens.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok (p);
            }
            catch (Exception ex)
            {
                return BadRequest (ex.Message);
            }
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> Get()
        {
            try
            {
                List<Personagem> lista = await _context.Personagens.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]

        public async Task<IActionResult> Add(Personagem novoPersonagem)
        {
            try
            {
                if(novoPersonagem.PontosVida > 100)
                {
                    throw new Exception ("Ponto de vida nao pode ser maior que 100");
                }
                await _context.Personagens.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();
                
                return Ok(novoPersonagem.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]

        public async Task<IActionResult> Update(Personagem novoPersonagem)
        {
            try
            {
                if(novoPersonagem.PontosVida > 100)
                {
                    throw new Exception("Pontos de vida não pode ser maior que 100");
                }
                _context.Personagens.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}