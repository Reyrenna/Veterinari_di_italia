﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.FarmaciaVenditaFarmaco;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var venditeList = await _venditaService.GetAllVenditeAsync();

                if (venditeList == null)
                {
                    return BadRequest(
                        new GetAllVenditaFarmacoResponseDto()
                        {
                            Message = "Qualcosa è andato storto",
                            Vendite = null,
                        }
                    );
                }

                List<VenditaFarmacoDto>? venditeDtoList = venditeList
                    .Select(v => new VenditaFarmacoDto()
                    {
                        IdVendita = v.IdVendita,
                        NumeroRicetta = v.NumeroRicetta,
                        DataAcquisto = v.DataAcquisto,
                        AcquirenteId = v.AcquirenteId,
                        Acquirente = new UserSimpleDto()
                        {
                            Id = v.Acquirente.Id,
                            Nome = v.Acquirente.Nome,
                            Cognome = v.Acquirente.Cognome,
                            CodiceFiscale = v.Acquirente.CodiceFiscale,
                            Email = v.Acquirente.Email,
                        },
                        FarmaciaVenditaFarmaco = v
                            .FarmaciaVenditaFarmaco.Select(
                                fvf => new GetVenditaFarmaciaVenditaFarmacoResponseDto()
                                {
                                    FarmaciaIdFarmaco = fvf.FarmaciaIdFarmaco,
                                    Farmaco = new FarmaciaSimpleDto()
                                    {
                                        IdFarmaco = fvf.Farmaco.IdFarmaco,
                                        Nome = fvf.Farmaco.Nome,
                                        DittaFornitrice = fvf.Farmaco.DittaFornitrice,
                                        ElencoUsi = fvf.Farmaco.ElencoUsi,
                                        Farmaco = fvf.Farmaco.Farmaco,
                                    },
                                }
                            )
                            .ToList(),
                    })
                    .ToList();

                var count = venditeDtoList.Count();

                return count == 1
                    ? Ok(
                        new GetAllVenditaFarmacoResponseDto()
                        {
                            Message = $"{count} vendita trovata!",
                            Vendite = venditeDtoList,
                        }
                    )
                    : Ok(
                        new GetAllVenditaFarmacoResponseDto()
                        {
                            Message = $"{count} vendite trovate!",
                            Vendite = venditeDtoList,
                        }
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{venditaId}")]
        public async Task<IActionResult> GetVendita(string venditaId)
        {
            try
            {
                var vendita = await _venditaService.GetVenditaByIdAsync(venditaId);

                if (vendita == null)
                {
                    return BadRequest(
                        new GetVenditaFarmacoByIdResponseDto()
                        {
                            Message = "Qualcosa è andato storto",
                            Vendita = null,
                        }
                    );
                }

                var venditaDto = new VenditaFarmacoDto()
                {
                    IdVendita = vendita.IdVendita,
                    NumeroRicetta = vendita.NumeroRicetta,
                    DataAcquisto = vendita.DataAcquisto,
                    AcquirenteId = vendita.AcquirenteId,
                    Acquirente = new UserSimpleDto()
                    {
                        Id = vendita.Acquirente.Id,
                        Nome = vendita.Acquirente.Nome,
                        Cognome = vendita.Acquirente.Cognome,
                        CodiceFiscale = vendita.Acquirente.CodiceFiscale,
                        Email = vendita.Acquirente.Email,
                    },
                    FarmaciaVenditaFarmaco = vendita
                        .FarmaciaVenditaFarmaco.Select(
                            fvf => new GetVenditaFarmaciaVenditaFarmacoResponseDto()
                            {
                                FarmaciaIdFarmaco = fvf.FarmaciaIdFarmaco,
                                Farmaco = new FarmaciaSimpleDto()
                                {
                                    IdFarmaco = fvf.Farmaco.IdFarmaco,
                                    Nome = fvf.Farmaco.Nome,
                                    DittaFornitrice = fvf.Farmaco.DittaFornitrice,
                                    ElencoUsi = fvf.Farmaco.ElencoUsi,
                                    Farmaco = fvf.Farmaco.Farmaco,
                                },
                            }
                        )
                        .ToList(),
                };

                return Ok(
                    new GetVenditaFarmacoByIdResponseDto()
                    {
                        Message = "Vendita trovata!",
                        Vendita = venditaDto,
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
            [FromBody] CreateVenditaFarmacoRequestDto createVenditaFarmaco
        )
        {
            try
            {
                var newGuidVendita = Guid.NewGuid();

                var newVendita = new VenditaFarmaco()
                {
                    IdVendita = newGuidVendita,
                    NumeroRicetta = createVenditaFarmaco.NumeroRicetta,
                    DataAcquisto = createVenditaFarmaco.DataAcquisto,
                    AcquirenteId = createVenditaFarmaco.AcquirenteId,
                    FarmaciaVenditaFarmaco = createVenditaFarmaco
                        .FarmaciaVenditaFarmaco.Select(f => new FarmaciaVenditaFarmaco()
                        {
                            FarmaciaIdFarmaco = f.FarmaciaIdFarmaco,
                            VenditaFarmacoIdVendita = newGuidVendita,
                        })
                        .ToList(),
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

        [HttpPut("{venditaId}")]
        public async Task<IActionResult> Edit(
            [FromBody] EditVenditaFarmacoRequestDto editVenditaFarmaco,
            string venditaId
        )
        {
            try
            {
                var venditaModificata = new VenditaFarmaco()
                {
                    DataAcquisto = editVenditaFarmaco.DataAcquisto,
                    NumeroRicetta = editVenditaFarmaco.NumeroRicetta,
                    AcquirenteId = editVenditaFarmaco.AcquirenteId,
                };

                var result = await _venditaService.EditVenditaByIdAsync(
                    venditaModificata,
                    venditaId
                );

                return result
                    ? Ok(
                        new EditVenditaFarmacoResponseDto()
                        {
                            Message = "Vendita modificata con successo!",
                        }
                    )
                    : BadRequest(
                        new EditVenditaFarmacoResponseDto()
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

        [HttpDelete("{venditaId}")]
        public async Task<IActionResult> Delete(string venditaId)
        {
            var result = await _venditaService.DeleteByIdAsync(venditaId);

            return result
                ? Ok(
                    new DeleteVenditaFarmacoResponseDto()
                    {
                        Message = "Vendita eliminata con successo!",
                    }
                )
                : BadRequest(
                    new DeleteVenditaFarmacoResponseDto() { Message = "Qualcosa è andato storto!" }
                );
        }
    }
}
