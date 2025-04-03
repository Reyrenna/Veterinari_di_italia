using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.GestioneRicoveri;
using Veterinari_di_italia.DTOs.TipoAnimale;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var ricoveriList = await _ricoveriService.GetAllRicoveriAsync();

                if (ricoveriList == null)
                {
                    return BadRequest(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = "Qualcosa è andato storto!",
                            Ricoveri = null,
                        }
                    );
                }

                var count = ricoveriList.Count();

                if (count == 0)
                {
                    return Ok(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = "Nessun ricovero trovato!",
                            Ricoveri = [],
                        }
                    );
                }

                var ricoveriDtoList = ricoveriList
                    .Select(r => new GestioneRicoveriDto()
                    {
                        IdRicovero = r.IdRicovero,
                        DataRicovero = r.DataRicovero,
                        Ricoverato = r.Ricoverato,
                        DescrizioneAnimale = r.DescrizioneAnimale,
                        IdAnimale = r.IdAnimale,
                        AnagraficaAnimale = new AnagraficaSimpleDTO()
                        {
                            DataRegistrazione = r.AnagraficaAnimale.DataRegistrazione,
                            Nome = r.AnagraficaAnimale.Nome,
                            TipologiaId = r.AnagraficaAnimale.TipologiaId,
                            Colore = r.AnagraficaAnimale.Colore,
                            DataDiNascita = r.AnagraficaAnimale.DataDiNascita,
                            PresenzaMicrochip = r.AnagraficaAnimale.PresenzaMicrochip,
                            NumeroMicroChip = r.AnagraficaAnimale.NumeroMicroChip,
                            ProprietarioId = r.AnagraficaAnimale.ProprietarioId,
                            Tipo = new TipologiaSimpleDto()
                            {
                                Id = r.AnagraficaAnimale.Tipo.Id,
                                TipoAnimale = r.AnagraficaAnimale.Tipo.TipoAnimale,
                            },
                            ProprietarioAnimale =
                                r.AnagraficaAnimale.ProprietarioAnimale != null
                                    ? new UserSimpleDto()
                                    {
                                        Id = r.AnagraficaAnimale.ProprietarioAnimale.Id,
                                        Nome = r.AnagraficaAnimale.ProprietarioAnimale.Nome,
                                        Cognome = r.AnagraficaAnimale.ProprietarioAnimale.Cognome,
                                        CodiceFiscale = r.AnagraficaAnimale
                                            .ProprietarioAnimale
                                            .CodiceFiscale,
                                        Email = r.AnagraficaAnimale.ProprietarioAnimale.Email,
                                    }
                                    : null,
                        },
                    })
                    .ToList();

                return count == 1
                    ? Ok(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = $"{count} ricovero trovato!",
                            Ricoveri = ricoveriDtoList,
                        }
                    )
                    : Ok(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = $"{count} ricoveri trovati!",
                            Ricoveri = ricoveriDtoList,
                        }
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("/ricoveriAttivi")]
        public async Task<IActionResult> GetAllRicoveriAttivi()
        {
            try
            {
                var ricoveriList = await _ricoveriService.GetAllRicoveriAttiviAsync();

                if (ricoveriList == null)
                {
                    return BadRequest(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = "Qualcosa è andato storto!",
                            Ricoveri = null,
                        }
                    );
                }

                var count = ricoveriList.Count();

                if (count == 0)
                {
                    return Ok(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = "Nessun ricovero trovato!",
                            Ricoveri = [],
                        }
                    );
                }

                var ricoveriDtoList = ricoveriList
                    .Select(r => new GestioneRicoveriDto()
                    {
                        IdRicovero = r.IdRicovero,
                        DataRicovero = r.DataRicovero,
                        Ricoverato = r.Ricoverato,
                        DescrizioneAnimale = r.DescrizioneAnimale,
                        IdAnimale = r.IdAnimale,
                        AnagraficaAnimale = new AnagraficaSimpleDTO()
                        {
                            DataRegistrazione = r.AnagraficaAnimale.DataRegistrazione,
                            Nome = r.AnagraficaAnimale.Nome,
                            TipologiaId = r.AnagraficaAnimale.TipologiaId,
                            Colore = r.AnagraficaAnimale.Colore,
                            DataDiNascita = r.AnagraficaAnimale.DataDiNascita,
                            PresenzaMicrochip = r.AnagraficaAnimale.PresenzaMicrochip,
                            NumeroMicroChip = r.AnagraficaAnimale.NumeroMicroChip,
                            ProprietarioId = r.AnagraficaAnimale.ProprietarioId,
                            Tipo = new TipologiaSimpleDto()
                            {
                                Id = r.AnagraficaAnimale.Tipo.Id,
                                TipoAnimale = r.AnagraficaAnimale.Tipo.TipoAnimale,
                            },
                            ProprietarioAnimale =
                                r.AnagraficaAnimale.ProprietarioAnimale != null
                                    ? new UserSimpleDto()
                                    {
                                        Id = r.AnagraficaAnimale.ProprietarioAnimale.Id,
                                        Nome = r.AnagraficaAnimale.ProprietarioAnimale.Nome,
                                        Cognome = r.AnagraficaAnimale.ProprietarioAnimale.Cognome,
                                        CodiceFiscale = r.AnagraficaAnimale
                                            .ProprietarioAnimale
                                            .CodiceFiscale,
                                        Email = r.AnagraficaAnimale.ProprietarioAnimale.Email,
                                    }
                                    : null,
                        },
                    })
                    .ToList();

                return count == 1
                    ? Ok(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = $"{count} ricovero trovato!",
                            Ricoveri = ricoveriDtoList,
                        }
                    )
                    : Ok(
                        new GetAllRicoveriResponseDto()
                        {
                            Message = $"{count} ricoveri trovati!",
                            Ricoveri = ricoveriDtoList,
                        }
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ricovero/{ricoveroId}")]
        public async Task<IActionResult> GetRicovero(string ricoveroId)
        {
            try
            {
                var ricovero = await _ricoveriService.GetRicoveroByIdAsync(ricoveroId);

                if (ricovero == null)
                {
                    return BadRequest(
                        new GetRicoveroResponseDto()
                        {
                            Message = "Qualcosa è andato storto!",
                            Ricovero = null,
                        }
                    );
                }

                var ricoveroDto = new GestioneRicoveriDto()
                {
                    IdRicovero = ricovero.IdRicovero,
                    DataRicovero = ricovero.DataRicovero,
                    Ricoverato = ricovero.Ricoverato,
                    DescrizioneAnimale = ricovero.DescrizioneAnimale,
                    IdAnimale = ricovero.IdAnimale,
                    AnagraficaAnimale = new AnagraficaSimpleDTO()
                    {
                        DataRegistrazione = ricovero.AnagraficaAnimale.DataRegistrazione,
                        Nome = ricovero.AnagraficaAnimale.Nome,
                        TipologiaId = ricovero.AnagraficaAnimale.TipologiaId,
                        Colore = ricovero.AnagraficaAnimale.Colore,
                        DataDiNascita = ricovero.AnagraficaAnimale.DataDiNascita,
                        PresenzaMicrochip = ricovero.AnagraficaAnimale.PresenzaMicrochip,
                        NumeroMicroChip = ricovero.AnagraficaAnimale.NumeroMicroChip,
                        ProprietarioId = ricovero.AnagraficaAnimale.ProprietarioId,
                        Tipo = new TipologiaSimpleDto()
                        {
                            Id = ricovero.AnagraficaAnimale.Tipo.Id,
                            TipoAnimale = ricovero.AnagraficaAnimale.Tipo.TipoAnimale,
                        },
                        ProprietarioAnimale =
                            ricovero.AnagraficaAnimale.ProprietarioAnimale != null
                                ? new UserSimpleDto()
                                {
                                    Id = ricovero.AnagraficaAnimale.ProprietarioAnimale.Id,
                                    Nome = ricovero.AnagraficaAnimale.ProprietarioAnimale.Nome,
                                    Cognome = ricovero
                                        .AnagraficaAnimale
                                        .ProprietarioAnimale
                                        .Cognome,
                                    CodiceFiscale = ricovero
                                        .AnagraficaAnimale
                                        .ProprietarioAnimale
                                        .CodiceFiscale,
                                    Email = ricovero.AnagraficaAnimale.ProprietarioAnimale.Email,
                                }
                                : null,
                    },
                };

                return Ok(
                    new GetRicoveroResponseDto()
                    {
                        Message = "Ricovero trovato!",
                        Ricovero = ricoveroDto,
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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

        [HttpPut("{ricoveroId}")]
        public async Task<IActionResult> Edit(
            [FromBody] EditGestioneRicoveriRequestDto editRicovero,
            string ricoveroId
        )
        {
            try
            {
                var ricoveroModified = new GestioneRicoveri()
                {
                    DataRicovero = editRicovero.DataRicovero,
                    Ricoverato = editRicovero.Ricoverato,
                    DescrizioneAnimale = editRicovero.DescrizioneAnimale,
                    IdAnimale = editRicovero.IdAnimale,
                };

                var result = await _ricoveriService.EditRicoveroByIdAsync(
                    ricoveroModified,
                    ricoveroId
                );

                return result
                    ? Ok(
                        new EditGestioneRicoveriResponsetDto()
                        {
                            Message = "Ricovero modificato con successo!",
                        }
                    )
                    : BadRequest(
                        new EditGestioneRicoveriResponsetDto()
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

        [HttpDelete("{ricoveroId}")]
        public async Task<IActionResult> Delete(string ricoveroId)
        {
            var result = await _ricoveriService.DeleteById(ricoveroId);

            return result
                ? Ok(
                    new DeleteGestioneRicoveriResponseDto()
                    {
                        Message = "Ricovero eliminato con successo!",
                    }
                )
                : BadRequest(
                    new DeleteGestioneRicoveriResponseDto()
                    {
                        Message = "Qualcosa è andato storto!",
                    }
                );
        }

        [HttpGet("RicercaRicoverato")]
        public async Task <IActionResult> Ricerca(string NumeroMicroChip )
        {
            if (NumeroMicroChip == "" && NumeroMicroChip == " ")
            {
                return BadRequest("ID tipologia non valido.");
            }

            var animale = await _ricoveriService.RicercaPerMicroChip(NumeroMicroChip);

           

            if (animale == null)
            {
                return NotFound("Nessun animale trovato per questa tipologia.");
            }

            try
            {
                var animaleDto = new AnagraficaDto()
                {
                    IdAnimale = animale.IdAnimale,
                    DataRegistrazione = animale.DataRegistrazione,
                    Nome = animale.Nome,
                    TipologiaId = animale.TipologiaId,
                    Tipo = new TipologiaSimpleDto()
                    {
                        Id = animale.Tipo.Id,
                        TipoAnimale = animale.Tipo.TipoAnimale,
                    },
                    Colore = animale.Colore,
                    DataDiNascita = animale.DataDiNascita,
                    PresenzaMicrochip = animale.PresenzaMicrochip,
                    NumeroMicroChip = animale.NumeroMicroChip,
                    ProprietarioId = animale.ProprietarioId,
                    ProprietarioAnimale = new UserSimpleDto()
                    {
                        Id = animale.ProprietarioAnimale.Id,
                        Nome = animale.ProprietarioAnimale.Nome,
                        Cognome = animale.ProprietarioAnimale.Cognome,
                        CodiceFiscale = animale.ProprietarioAnimale.CodiceFiscale,
                        Email = animale.ProprietarioAnimale.Email,
                    },

                    GestioneRicoveris = animale.gestioneRicoveris.Select(r => new GestioneRicoveriSimpleDto()
                    {
                        IdRicovero = r.IdRicovero,
                        DataRicovero = r.DataRicovero,
                        Ricoverato = r.Ricoverato,
                        DescrizioneAnimale = r.DescrizioneAnimale,
                    }).ToList(),

                };

            }
            catch
            {
                return StatusCode(500);
            }

            return Ok(animale);
        }
    }
}
