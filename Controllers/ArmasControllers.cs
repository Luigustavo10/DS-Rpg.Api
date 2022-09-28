using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using RpgApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ArmasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Armas p = await _dataContext.Armas
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Armas> lista = await _dataContext.Armas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new Exception("O dano não pode ser maior que 100");
                }
                await _dataContext.Armas.AddAsync(novaArma);
                await _dataContext.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Armas novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new Exception("O dano não pode ser maior que 100");
                }
                _dataContext.Armas.Update(novaArma);
                int linhasAfetadas = await _dataContext.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Armas pRemover = await _dataContext.Armas
                .FirstOrDefaultAsync(p => p.Id == id);

                _dataContext.Armas.Remove(pRemover);
                int linhasAfetadas = await _dataContext.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}