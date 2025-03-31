using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly Jwt _jwtSettings;
        private readonly VisiteVeterinarie _visite;

        public AppointmentController(
            Jwt jwtSettings, VisiteVeterinarie visite)
        {
            _jwtSettings = jwtSettings;
            _visite = visite;
        }

        [HttpPost("register")]
        public Task<IActionResult> RegisterVisit([FromBody] CreateVisitDto createVisit)
        {
            if (createVisit == null)
            {
                return Task.FromResult<IActionResult>(BadRequest("dati non corretti"));
            }

            try
            {
                var newVisit = new VisiteVeterinarie()
                {
                    DataDellaVisita = createVisit.DataDellaVisita,
                    EsameObiettivo = createVisit.EsameObiettivo,
                    Descrizione = createVisit.Descrizione
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

    }
}
