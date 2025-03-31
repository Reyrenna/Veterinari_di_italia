using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.Farmaci;
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
        public async Task<IActionResult> Create([FromBody] CreateFarmaciDTO createFarmaciDTO)
        {
            if (createFarmaciDTO == null)
            {
                return BadRequest("Il corpo della richiesta non può essere nullo.");
            }

            try
            {
                var newFarmaci = new CreateFarmaciDTO()
                {
                    Nome = createFarmaciDTO.Nome,
                    DittaFornitrice = createFarmaciDTO.DittaFornitrice,
                    ElencoUsi = createFarmaciDTO.ElencoUsi
                };

                var result = await _farmaciService.CreateFarmaci(newFarmaci);
                if (result)
                {
                    return Ok();
                }
                return BadRequest("Errore durante la creazione del farmaco.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante la creazione del farmaco: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFarmaci()
        {
            try
            {
                var farmaci = await _farmaciService.GetFarmaci();
                if (farmaci == null || !farmaci.Any())
                {
                    return NotFound("Nessun farmaco trovato.");
                }
                return Ok(farmaci);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante il recupero dei farmaci: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetFarmaciById(Guid id)
        {
            try
            {
                var farmaci = await _farmaciService.GetFarmaciById(id);
                if (farmaci == null)
                {
                    return NotFound("Farmaco non trovato.");
                }
                return Ok(farmaci);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante il recupero del farmaco: {ex.Message}");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateFarmaco(Guid id, [FromBody] CreateFarmaciDTO createFarmaciDTO)
        {
            if (createFarmaciDTO == null)
            {
                return BadRequest("Il corpo della richiesta non può essere nullo.");
            }
            try
            {
                var newFarmaci = new CreateFarmaciDTO()
                {
                    Nome = createFarmaciDTO.Nome,
                    DittaFornitrice = createFarmaciDTO.DittaFornitrice,
                    ElencoUsi = createFarmaciDTO.ElencoUsi
                };
                var result = await _farmaciService.UpdateFarmaco(id, newFarmaci);
                if (result)
                {
                    return Ok();
                }
                return BadRequest("Errore durante l'aggiornamento del farmaco.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante l'aggiornamento del farmaco: {ex.Message}");
            }
        }

        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> DeleteFarmaci(Guid id)
        {
            try
            {
                var result = await _farmaciService.DeleteFarmaco(id);
                if (result)
                {
                    return Ok();
                }
                return BadRequest("Errore durante l'eliminazione del farmaco.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante l'eliminazione del farmaco: {ex.Message}");
            }
        }

    }

}
