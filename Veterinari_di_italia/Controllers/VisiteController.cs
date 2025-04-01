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
    }
}
