using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Services;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagraficaAnimaleController : ControllerBase
    {
        private readonly AnagraficaAnimaleService _anagraficaAnimaleService;

        public AnagraficaAnimaleController(AnagraficaAnimaleService anagraficaAnimaleService)
        {
            _anagraficaAnimaleService = anagraficaAnimaleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateAnagraficaRequestDto createAnagrafica
        )
        {
            var newAnagrafica = new AnagraficaAnimale()
            {
                DataRegistrazione = createAnagrafica.DataRegistrazione,
                Nome = createAnagrafica.Nome,
                Colore = createAnagrafica.Colore,
                DataDiNascita = createAnagrafica.DataDiNascita,
                PresenzaMicrochip = createAnagrafica.PresenzaMicrochip,
                NumeroMicroChip = createAnagrafica.NumeroMicrochip,
                TipologiaId = createAnagrafica.TipologiaId,
                ProprietarioId = createAnagrafica.ProprietarioId,
            };

            var result = await _anagraficaAnimaleService.CreateAnagraficaAsync(newAnagrafica);

            return result
                ? Ok(
                    new CreateAnagraficaResponseDto()
                    {
                        Message = "Anagrafica creata con successo!",
                    }
                )
                : BadRequest(
                    new CreateAnagraficaResponseDto() { Message = "Qualcosa è andato storto!" }
                );
        }
    }
}
