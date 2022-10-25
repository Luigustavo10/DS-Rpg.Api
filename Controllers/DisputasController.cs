using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Text;
using RpgApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;
        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsync(Disputa d)
        {
            try
            {
                Personagem atacante = await _context.Personagens
                .Include(p => p.Armas)
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);



                Personagem oponente = await _context.Personagens
                .FirstOrDefaultAsync(p => p.Id == d.OponenteId);
                int dano = atacante.Armas.Dano + (new Random().Next(atacante.Forca));
                dano = dano - new Random().Next(oponente.Defesa);
                if (dano > 0)
                    oponente.PontosVida = oponente.PontosVida - (int)dano;
                if (oponente.PontosVida <= 0)



                    d.Narracao = $"{oponente.Nome} foi derrotado!";
                _context.Personagens.Update(oponente);
                await _context.SaveChangesAsync();

                StringBuilder dados = new StringBuilder();
                dados.AppendFormat(" Atacante {0}. ", atacante.Nome);
                dados.AppendFormat(" Oponente {0}. ", atacante.Nome);
                dados.AppendFormat(" Pontos de vida do atacante {0}. ", atacante.PontosVida);
                dados.AppendFormat(" Pontos de vida do oponente {0}. ", atacante.PontosVida);
                dados.AppendFormat(" Arma Utilizada. ", atacante.Armas.Nome);
                dados.AppendFormat(" Dano : {0}. ", dano);

                d.Narracao += dados.ToString();
                d.DataDisputa = DateTime.Now;
                _context.Disputas.Add(d);
                _context.SaveChanges();

                return Ok(d);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidadeAsync(Disputa d)
        {
            try
            {
                Personagem atacante = await _context.Personagens
                .Include(p => p.PersonagemHabilidade)
                .ThenInclude(ph => ph.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);

                Personagem oponente = await _context.Personagens
                .FirstOrDefaultAsync(p => p.Id == d.OponenteId);

                PersonagemHabilidade ph = await _context.PersonagemHabilidade
                .Include(p => p.Habilidade)
                .FirstOrDefaultAsync(phBusca => phBusca.HabilidadeId == d.HabilidadeId && phBusca.PersonagemId == d.AtacanteId);

                return Ok(d);
                }
                 catch (System.Exception ex)
               {
                return BadRequest(ex.Message);
               }


                
            }
           
        

        [HttpGet("PersonagemRandom")]

        public async Task<IActionResult> Sorteio()
        {
            List<Personagem> personagens = await _context.Personagens.ToListAsync();

            int Sorteio = new Random() .Next(personagens.Count);

            Personagem p = personagens[Sorteio];

            string msg = string.Format("Número Sorteado {0}. Personagem {1}", Sorteio, p.Nome);

            return Ok(msg);
        }
}

    }




