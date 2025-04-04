using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.Farmaci;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Services;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmaciController : ControllerBase
    {
        private readonly FarmaciService _farmaciService;

        public FarmaciController(FarmaciService farmaciService)
        {
            _farmaciService = farmaciService;
        }

        [HttpPost]
        [Authorize(Roles = "Farmacista, Veterinario, Admin")]
        public async Task<IActionResult> Create([FromBody] CreateFarmaciDTO createFarmaciDTO)
        {
            if (createFarmaciDTO == null)
            {
                return BadRequest(new CreateFarmaciResponseDTO() { Message = "Dati non trovati" });
            }

            try
            {
                var newFarmaci = new Farmacia()
                {
                    Nome = createFarmaciDTO.Nome,
                    DittaFornitrice = createFarmaciDTO.DittaFornitrice,
                    ElencoUsi = createFarmaciDTO.ElencoUsi,
                    Farmaco = createFarmaciDTO.Farmaco,
                    Posizione = createFarmaciDTO.Posizione,
                };

                var result = await _farmaciService.CreateFarmaci(newFarmaci);
                if (result)
                {
                    return Ok(
                        new CreateFarmaciResponseDTO() { Message = "Farmaco creato con successo!" }
                    );
                }
                return BadRequest(
                    new CreateFarmaciResponseDTO()
                    {
                        Message = "Errore durante la creazione del farmaco.",
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Errore durante la creazione del farmaco: {ex.Message}"
                );
            }
        }

        [HttpGet]
        [Authorize(Roles = "Farmacista, Veterinario, Admin")]
        public async Task<IActionResult> GetFarmaci()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new GetAllFarmaciResponseDTO() { Message = "Dati non validi." });
            }
            try
            {
                var farmaci = await _farmaciService.GetFarmaci();
                if (farmaci == null || !farmaci.Any())
                {
                    return NotFound(
                        new CreateFarmaciResponseDTO() { Message = "Nessun farmaco trovato." }
                    );
                }
                return Ok(farmaci);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Errore durante il recupero dei farmaci: {ex.Message}"
                );
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Farmacista, Veterinario, Admin")]
        public async Task<IActionResult> GetFarmaciById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new GetFarmaciResponseDTO() { Message = "Dati non validi." });
            }
            try
            {
                var farmaci = await _farmaciService.GetFarmaciById(id);
                if (farmaci == null)
                {
                    return NotFound(
                        new GetFarmaciResponseDTO() { Message = "Farmaco non trovato." }
                    );
                }
                return Ok(farmaci);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Errore durante il recupero del farmaco: {ex.Message}"
                );
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Farmacista, Admin")]
        public async Task<IActionResult> UpdateFarmaco(
            Guid id,
            [FromBody] CreateFarmaciDTO createFarmaciDTO
        )
        {
            if (createFarmaciDTO == null)
            {
                return BadRequest(
                    new EditFarmaciResponseDTO()
                    {
                        Message = "Il corpo della richiesta non può essere nullo.",
                    }
                );
            }
            try
            {
                var newFarmaci = new CreateFarmaciDTO()
                {
                    Nome = createFarmaciDTO.Nome,
                    DittaFornitrice = createFarmaciDTO.DittaFornitrice,
                    ElencoUsi = createFarmaciDTO.ElencoUsi,
                    Farmaco = createFarmaciDTO.Farmaco,
                    Posizione = createFarmaciDTO.Posizione,
                };
                var result = await _farmaciService.UpdateFarmaco(id, newFarmaci);
                if (result)
                {
                    return Ok(
                        new EditFarmaciResponseDTO() { Message = "Modifica compiuta con successo" }
                    );
                }
                return BadRequest(
                    new EditFarmaciResponseDTO()
                    {
                        Message = "Errore durante l'aggiornamento del farmaco.",
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Errore durante l'aggiornamento del farmaco: {ex.Message}"
                );
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Farmacista, Admin")]
        public async Task<IActionResult> DeleteFarmaci(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new DeleteFarmaciResponseDTO() { Message = "Dati non validi." });
            }
            try
            {
                var result = await _farmaciService.DeleteFarmaco(id);
                if (result)
                {
                    return Ok(
                        new DeleteFarmaciResponseDTO()
                        {
                            Message = "Farmaco eliminato con successo!",
                        }
                    );
                }
                return BadRequest(
                    new DeleteFarmaciResponseDTO()
                    {
                        Message = "Errore durante l'eliminazione del farmaco.",
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Errore durante l'eliminazione del farmaco: {ex.Message}"
                );
            }
        }

        [HttpGet("posizioneFarmaco/{farmacoId:guid}")]
        [Authorize(Roles = "Farmacista, Admin")]
        public async Task<IActionResult> GetPosizioneFarmaco(Guid farmacoId)
        {
            try
            {
                var farmaco = await _farmaciService.GetFarmaciById(farmacoId);

                if (farmaco == null)
                {
                    return BadRequest(
                        new GetFarmacoPosizioneResponseDto()
                        {
                            Message = "Farmaco non trovato!",
                            Posizione = null,
                        }
                    );
                }

                return Ok(
                    new GetFarmacoPosizioneResponseDto()
                    {
                        Message = "Farmaco trovato!",
                        Posizione = farmaco.Posizione,
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
