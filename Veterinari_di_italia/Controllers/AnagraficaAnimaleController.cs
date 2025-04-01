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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var anagraficheList = await _anagraficaAnimaleService.GetAllAsync();

            if (anagraficheList == null)
            {
                return BadRequest();
            }

            var count = anagraficheList.Count();

            return anagraficheList.Count() == 1
                ? Ok(
                    new GetAllAnagraficheResponseDto()
                    {
                        Message = $"{count} anagrafica trovata!",
                        Anagrafiche = anagraficheList,
                    }
                )
                : Ok(
                    new GetAllAnagraficheResponseDto()
                    {
                        Message = $"{count} anagrafiche trovate!",
                        Anagrafiche = anagraficheList,
                    }
                );
        }

        // TODO completare
        [HttpGet("anagrafica/{anagraficaId}")]
        public async Task<IActionResult> GetAnagrafica(string anagraficaId)
        {
            var anagraficaFound = await _anagraficaAnimaleService.GetByIdAsync(anagraficaId);

            return anagraficaFound == null
                ? Ok(
                    new GetAnagraficaResponseDto()
                    {
                        Message = "Nessuna anagrafica trovata!",
                        Anagrafica = null,
                    }
                )
                : Ok(
                    new GetAnagraficaResponseDto()
                    {
                        Message = "Anagrafica trovata",
                        Anagrafica = anagraficaFound,
                    }
                );
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

        [HttpPut("anagraficaId")]
        public async Task<IActionResult> Edit(
            [FromBody] EditAnagraficaRequestDto editAnagrafica,
            string anagraficaId
        )
        {
            try
            {
                var anagraficaModificata = new AnagraficaAnimale()
                {
                    DataRegistrazione = editAnagrafica.DataRegistrazione,
                    Nome = editAnagrafica.Nome,
                    Colore = editAnagrafica.Colore,
                    DataDiNascita = editAnagrafica.DataDiNascita,
                    PresenzaMicrochip = editAnagrafica.PresenzaMicrochip,
                    NumeroMicroChip = editAnagrafica.NumeroMicrochip,
                    ProprietarioId = editAnagrafica.ProprietarioId,
                    TipologiaId = editAnagrafica.TipologiaId,
                };

                var result = await _anagraficaAnimaleService.EditAnagraficaAsync(
                    anagraficaModificata,
                    anagraficaId
                );

                return result
                    ? Ok(
                        new EditAnagraficaResponseDto()
                        {
                            Message = "Anagrafica modificata con successo!",
                        }
                    )
                    : BadRequest(
                        new EditAnagraficaResponseDto() { Message = "Qualcosa è andato storto!" }
                    );
            }
            catch
            {
                return BadRequest(
                    new EditAnagraficaResponseDto() { Message = "Qualcosa è andato storto!" }
                );
            }
        }

        [HttpDelete("delete/{anagraficaId}")]
        public async Task<IActionResult> Delete(string anagraficaId)
        {
            var result = await _anagraficaAnimaleService.DeleteById(anagraficaId);

            return result
                ? Ok(
                    new DeleteAnagraficaResponseDto()
                    {
                        Message = "Anagrafica cancellata con successo!",
                    }
                )
                : BadRequest(
                    new DeleteAnagraficaResponseDto() { Message = "Qualcosa è andatoi storto!" }
                );
        }
    }
}
