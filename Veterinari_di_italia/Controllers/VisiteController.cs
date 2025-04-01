using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Settings;
using Microsoft.AspNetCore.Http;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;
using Veterinari_di_italia.Services;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiteController : ControllerBase
    {
        private readonly VisiteService _visiteservice;

        public VisiteController(VisiteService visiteservice)
        {
            _visiteservice = visiteservice;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] CreateVisitDtoRequest createVisit)
        {
            if (createVisit == null)
            {
                return BadRequest(new CreateVisitDtoResponse() { Message = "i dati non sono corretti" });
            }

            try
            {
                var newVisit = new VisiteVeterinarie()
                {
                    DataDellaVisita = createVisit.DataDellaVisita,
                    EsameObiettivo = createVisit.EsameObiettivo,
                    Descrizione = createVisit.Descrizione
                };
                var result = await _visiteservice.CreateVisita(newVisit);
                if (result)
                {
                    return Ok(new CreateVisitDtoResponse() { Message = "i dati sono corretti" });
                }

                return BadRequest(new CreateVisitDtoResponse() { Message = "i dati non sono corretti" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _visiteservice.GetAllAsync();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetVisitById(int id)
        {
            try
            {
                var result = await _visiteservice.GetVisitaById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateVisit([FromBody] EditVisitDtoRequest updateVisit, int id)
        {
            if (updateVisit == null)
            {
                return BadRequest(new EditVisitDtoResponse() { Message = "i dati non sono corretti" });
            }
            try
            {
                var newVisit = new VisiteVeterinarie()
                {
                    DataDellaVisita = updateVisit.DataDellaVisita,
                    EsameObiettivo = updateVisit.EsameObiettivo,
                    Descrizione = updateVisit.Descrizione
                };
                var result = await _visiteservice.EditVisite(newVisit, id);
                if (result)
                {
                    return Ok(new EditVisitDtoResponse() { Message = "i dati sono corretti" });
                }
                return BadRequest(new EditVisitDtoResponse() { Message = "i dati non sono corretti" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteVisit(int id)
        {
            try
            {
                var result = await _visiteservice.DeleteVisita(id);
                if (result)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
