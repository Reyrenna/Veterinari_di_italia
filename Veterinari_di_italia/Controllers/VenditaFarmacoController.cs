using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.VenditaFarmaco;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Services;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenditaFarmacoController : ControllerBase
    {
        private readonly VenditaFarmacoService _venditaService;

        public VenditaFarmacoController(VenditaFarmacoService venditaService)
        {
            _venditaService = venditaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateVenditaFarmacoRequestDto createVenditaFarmaco
        )
        {
            try
            {
                var newVendita = new VenditaFarmaco()
                {
                    NumeroRicetta = createVenditaFarmaco.NumeroRicetta,
                    DataAcquisto = createVenditaFarmaco.DataAcquisto,
                    AcquirenteId = createVenditaFarmaco.AcquirenteId,
                };

                var result = await _venditaService.CreateVenditaFarmacoAsync(newVendita);

                return result
                    ? Ok(
                        new CreateVenditaFarmacoResponseDto()
                        {
                            Message = "Vendita creata con successo!",
                        }
                    )
                    : BadRequest(
                        new CreateVenditaFarmacoResponseDto()
                        {
                            Message = "Qualcosa è andato storto!",
                        }
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
