using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.GestioneRicoveri;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Services;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestioneRicoveriController : ControllerBase
    {
        private readonly GestioneRicoveriService _ricoveriService;

        public GestioneRicoveriController(GestioneRicoveriService ricoveriService)
        {
            _ricoveriService = ricoveriService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateGestioneRicoveriRequestDto createRicovero
        )
        {
            try
            {
                var ricovero = new GestioneRicoveri()
                {
                    DataRicovero = createRicovero.DataRicovero,
                    Ricoverato = createRicovero.Ricoverato,
                    DescrizioneAnimale = createRicovero.DescrizioneAnimale,
                    IdAnimale = createRicovero.IdAnimale,
                };

                var result = await _ricoveriService.CreateRicoveroAsync(ricovero);

                return result
                    ? Ok(
                        new CreateGestioneRicoveriResponseDto()
                        {
                            Message = "Ricovero creato con successo!",
                        }
                    )
                    : BadRequest(
                        new CreateGestioneRicoveriResponseDto()
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
