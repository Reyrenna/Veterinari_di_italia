using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("animale/{animaleId}")]
        public async Task<IActionResult> GetRicoveriByAnimaleId(string animaleId)
        {
            try
            {
                var ricoveriList = await _ricoveriService.GetRicoveriByAnimaleIdAsync(animaleId);

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

                var ricoveri = new GestioneRicoveriDto()
                {
                    IdRicovero = ricoveriList.IdRicovero,
                    DataRicovero = ricoveriList.DataRicovero,
                    Ricoverato = ricoveriList.Ricoverato,
                    DescrizioneAnimale = ricoveriList.DescrizioneAnimale,
                    IdAnimale = ricoveriList.IdAnimale,
                    AnagraficaAnimale = new AnagraficaSimpleDTO()
                    {
                        DataRegistrazione = ricoveriList.AnagraficaAnimale.DataRegistrazione,
                        Nome = ricoveriList.AnagraficaAnimale.Nome,
                        TipologiaId = ricoveriList.AnagraficaAnimale.TipologiaId,
                        Tipo = new TipologiaSimpleDto()
                        {
                            Id = ricoveriList.AnagraficaAnimale.Tipo.Id,
                            TipoAnimale = ricoveriList.AnagraficaAnimale.Tipo.TipoAnimale,
                        },
                        Colore = ricoveriList.AnagraficaAnimale.Colore,
                        DataDiNascita = ricoveriList.AnagraficaAnimale.DataDiNascita,
                        PresenzaMicrochip = ricoveriList.AnagraficaAnimale.PresenzaMicrochip,
                        NumeroMicroChip = ricoveriList.AnagraficaAnimale.NumeroMicroChip,
                        ProprietarioId = ricoveriList.AnagraficaAnimale.ProprietarioId,
                        ProprietarioAnimale = new UserSimpleDto()
                        {
                            Id = ricoveriList.AnagraficaAnimale.ProprietarioAnimale.Id,
                            Nome = ricoveriList.AnagraficaAnimale.ProprietarioAnimale.Nome,
                            Cognome = ricoveriList.AnagraficaAnimale.ProprietarioAnimale.Cognome,
                            CodiceFiscale = ricoveriList
                                .AnagraficaAnimale.ProprietarioAnimale.CodiceFiscale,
                            Email = ricoveriList.AnagraficaAnimale.ProprietarioAnimale.Email,
                        },

                    }
                };

                return Ok(
                    new GetAllRicoveriResponseDto()
                    {
                        Message = "Ricoveri trovati!",
                        Ricoveri = new List<GestioneRicoveriDto> { ricoveri },
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
                        new EditGestioneRicoveriResponseDto()
                        {
                            Message = "Ricovero modificato con successo!",
                        }
                    )
                    : BadRequest(
                        new EditGestioneRicoveriResponseDto()
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
    }
}
