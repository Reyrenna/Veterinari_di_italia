using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.TipoAnimale;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Services;

namespace Veterinari_di_italia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipologieAnimaliController : ControllerBase
    {
        private readonly TipologiaAnimaliService _tipologiaAnimaliService;

        public TipologieAnimaliController(TipologiaAnimaliService tipologiaAnimaliService)
        {
            _tipologiaAnimaliService = tipologiaAnimaliService;
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateTipoAnimaleRequestDTO createTipoAnimaleRequestDTO)
        {
            if (createTipoAnimaleRequestDTO == null)
            {
                return BadRequest(new CreateTipoAnimaleResponseDTO() { Message = "Dati non trovati" });
            }
            try
            {
                var newTipoAnimale = new TipologiaAnimale()
                {
                    TipoAnimale = createTipoAnimaleRequestDTO.TipoAnimale
                };
                var result = await _tipologiaAnimaliService.CreateTipologiaAsync(newTipoAnimale);
                if (result)
                {
                    return Ok(new CreateTipoAnimaleResponseDTO() { Message = "Tipologia animale creata con successo!" });
                }
                return BadRequest(new CreateTipoAnimaleResponseDTO() { Message = "Errore durante la creazione della tipologia animale." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante la creazione della tipologia animale: {ex.Message}");
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetTipi()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new GetAllTipoAnimaleResponseDTO() { Message = "Dati non validi." });
            }
            try
            {
                var tipologia = await _tipologiaAnimaliService.GetAllTipoAnimale();
                if (tipologia == null || !tipologia.Any())
                {
                    return NotFound(new GetAllTipoAnimaleResponseDTO() { Message = "Tipologia animale non trovata." });
                }
                return Ok(tipologia);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante la ricerca della tipologia animale: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetTipo(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new GetByIdTipoAnimaleResponseDTO() { Message = "Dati non validi." });
            }
            try
            {
                var tipologia = await _tipologiaAnimaliService.GetTipoAnimaleById(id);
                if (tipologia == null)
                {
                    return NotFound(new GetByIdTipoAnimaleResponseDTO() { Message = "Tipologia animale non trovata." });
                }
                return Ok(tipologia);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante la ricerca della tipologia animale: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> UpdateTipo(int id, [FromBody] EditTipoAnimaleRequestDTO editTipoAnimale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new EditTipoAnimaleResponseDTO() { Message = "Dati non validi." });
            }

            try
            {
                var newTipo = new TipologiaAnimale()
                {
                    TipoAnimale = editTipoAnimale.TipoAnimale
                };
                var result = await _tipologiaAnimaliService.UpdateTipologiaAsync(id ,newTipo);
                if (result)
                {
                    return Ok(new EditTipoAnimaleResponseDTO() { Message = "Tipologia animale aggiornata con successo!" });
                }
                return BadRequest(new EditTipoAnimaleResponseDTO() { Message = "Errore durante l'aggiornamento della tipologia animale." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante l'aggiornamento della tipologia animale: {ex.Message}");
            }

        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteTipo(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new DeleteTipoAnimaleResponseDTO() { Message = "Dati non validi." });
            }
            try
            {
                var result = await _tipologiaAnimaliService.DeleteTipologiaAsync(id);
                if (result)
                {
                    return Ok(new DeleteTipoAnimaleResponseDTO() { Message = "Tipologia animale eliminata con successo!" });
                }
                return BadRequest(new DeleteTipoAnimaleResponseDTO() { Message = "Errore durante l'eliminazione della tipologia animale." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Errore durante l'eliminazione della tipologia animale: {ex.Message}");
            }
        }

    }
}
