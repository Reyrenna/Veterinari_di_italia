using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.FarmaciaVisiteVeterinarie;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;
using Veterinari_di_italia.Models;
using Veterinari_di_italia.Services;
using Veterinari_di_italia.Settings;

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
        [Authorize(Roles = "Veterinario, Admin")]
        public async Task<IActionResult> CreateVisit([FromBody] CreateVisitDtoRequest createVisit)
        {
            if (createVisit == null)
            {
                return BadRequest(
                    new CreateVisitDtoResponse() { Message = "i dati non sono corretti" }
                );
            }

            try
            {
                var newGuidVisita = Guid.NewGuid();

                var newVisit = new VisiteVeterinarie()
                {
                    DataDellaVisita = createVisit.DataDellaVisita,
                    EsameObiettivo = createVisit.EsameObiettivo,
                    Descrizione = createVisit.Descrizione,
                    IdAnimale = Guid.Parse(createVisit.IdAnagraficaAnimale),
                };
                var result = await _visiteservice.CreateVisita(newVisit);

                if (!result)
                {
                    return BadRequest(
                        new CreateVisitDtoResponse() { Message = "i dati non sono corretti" }
                    );
                }

                var visitId = await _visiteservice.GetVisitaIdAsync(newVisit);

                if (visitId == null)
                {
                    return BadRequest(
                        new CreateVisitDtoResponse() { Message = "i dati non sono corretti" }
                    );
                }

                int id = (int)visitId;
                foreach (var element in createVisit.Farmaci)
                {
                    var collegamento = new FarmaciaVisiteVeterinarie()
                    {
                        FarmacoId = element.FarmacoId,
                        VisitaId = id,
                    };

                    var res = await _visiteservice.AddRelationAsync(collegamento);

                    if (!res)
                    {
                        return BadRequest(
                            new CreateVisitDtoResponse() { Message = "i dati non sono corretti" }
                        );
                    }
                }

                return Ok(new CreateVisitDtoResponse() { Message = "i dati sono corretti" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Veterinario, Admin")]
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
        [Authorize(Roles = "Veterinario, Admin")]
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
        [Authorize(Roles = "Veterinario, Admin")]
        public async Task<IActionResult> UpdateVisit(
            [FromBody] EditVisitDtoRequest updateVisit,
            int id
        )
        {
            if (updateVisit == null)
            {
                return BadRequest(
                    new EditVisitDtoResponse() { Message = "i dati non sono corretti" }
                );
            }
            try
            {
                var newVisit = new VisiteVeterinarie()
                {
                    DataDellaVisita = updateVisit.DataDellaVisita,
                    EsameObiettivo = updateVisit.EsameObiettivo,
                    Descrizione = updateVisit.Descrizione,
                    IdAnimale = updateVisit.IdAnagraficaAnimale,
                    FarmaciaVisiteVeterinaries = updateVisit
                        .Farmaco.Select(f => new FarmaciaVisiteVeterinarie()
                        {
                            FarmacoId = f.FarmaciaIdFarmaco,
                        })
                        .ToList(),
                };
                var result = await _visiteservice.EditVisite(newVisit, id);
                if (result)
                {
                    return Ok(new EditVisitDtoResponse() { Message = "i dati sono corretti" });
                }
                return BadRequest(
                    new EditVisitDtoResponse() { Message = "i dati non sono corretti" }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Veterinario, Admin")]
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

        [HttpGet("/allVisite/{idAnimale}")]
        public async Task<IActionResult> GetAllVisiteByAnimalId(string idAnimale)
        {
            try
            {
                var visitsList = await _visiteservice.GetAllVisiteByAnimalIdAsync(idAnimale);

                if (visitsList == null)
                {
                    return BadRequest(
                        new GetAllVisiteByAnimalIdResponseDto()
                        {
                            Message = "Qualcosa è andato storto!",
                            Visite = null,
                        }
                    );
                }

                var visitsDtoList = visitsList
                    .Select(v => new VisiteVeterinarieSimpleDto()
                    {
                        Descrizione = v.Descrizione,
                        EsameObiettivo = v.EsameObiettivo,
                        DataDellaVisita = v.DataDellaVisita,
                        Id = v.Id,
                        Anagrafica = new AnagraficaSimpleDTO()
                        {
                            Nome = v.AnagraficaAnimale.Nome,
                            Colore = v.AnagraficaAnimale.Colore,
                            DataDiNascita = v.AnagraficaAnimale.DataDiNascita,
                            DataRegistrazione = v.AnagraficaAnimale.DataRegistrazione,
                            PresenzaMicrochip = v.AnagraficaAnimale.PresenzaMicrochip,
                            NumeroMicroChip = v.AnagraficaAnimale.NumeroMicroChip,
                            ProprietarioId = v.AnagraficaAnimale.ProprietarioId,
                            TipologiaId = v.AnagraficaAnimale.TipologiaId,
                        },
                        FarmaciVisiteVeterinarie = v
                            .FarmaciaVisiteVeterinaries.Select(
                                fvv => new GetFarmaciFarmaciaVisiteVeterinarieDto()
                                {
                                    FarmacoId = fvv.FarmacoId,
                                    Farmaco = new FarmaciaSimpleDto()
                                    {
                                        IdFarmaco = fvv.Farmaco.IdFarmaco,
                                        Nome = fvv.Farmaco.Nome,
                                        DittaFornitrice = fvv.Farmaco.DittaFornitrice,
                                        ElencoUsi = fvv.Farmaco.ElencoUsi,
                                        Farmaco = fvv.Farmaco.Farmaco,
                                    },
                                }
                            )
                            .ToList(),
                    })
                    .ToList();

                var count = visitsDtoList.Count;

                return Ok(
                    new GetAllVisiteByAnimalIdResponseDto()
                    {
                        Message =
                            count == 1 ? $"{count} visita trovata!" : $"{count} visite trovate!",
                        Visite = visitsDtoList,
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
