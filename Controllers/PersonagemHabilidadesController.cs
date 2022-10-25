using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Data;
using System.Threading.Tasks;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonagemHabilidadesController (DataContext context) { _context = context; }
        [HttpGet("{personagemId}")]
        public async Task<IActionResult> GetHabilidadesPersonagem(int personagemId)
        {
            try
            {
                List<PersonagemHabilidade> phLista = new List<PersonagemHabilidade>();

                phLista = await _context.PersonagemHabilidade
                    .Include(p => p.Personagem)
                    .Include(p => p.Habilidade)
                    .Where(p => p.Personagem.Id == personagemId).ToListAsync();

                return Ok(phLista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetHabilidades")]
        public async Task<IActionResult> GetHabilidades()
        {
            try
            {
                List<Habilidades> habilidades = new List<Habilidades>();
                habilidades = await _context.Habilidades.ToListAsync();
                return Ok(habilidades);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("DeletePersonagemHabilidade")]
        public async Task<IActionResult> DeleteAsync(PersonagemHabilidade ph)
        {
            try
            {
                PersonagemHabilidade phRemover = await _context.PersonagemHabilidade    
                .FirstOrDefaultAsync(phBusca => phBusca.PersonagemId == ph.PersonagemId
                && phBusca.HabilidadeId == ph.HabilidadeId);
                
                if (phRemover == null)
                    throw new System.Exception("Personagem ou Habilidade não encontrados");

                _context.PersonagemHabilidade.Remove(phRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
