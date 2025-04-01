using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.DTOs.Farmacia;
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
                        Farmacia = (ICollection<FarmaciaSimpleDto>?)(
                            v.Farmacia.Count > 0
                                ? v.Farmacia.Select(f => new FarmaciaSimpleDto()
                                {
                                    IdFarmaco = f.IdFarmaco,
                                    Nome = f.Nome,
                                    DittaFornitrice = f.DittaFornitrice,
                                    ElencoUsi = f.ElencoUsi,
                                    VenditaFarmaco =
                                        f.VenditaFarmaco.Count > 0
                                            ? f
                                                .VenditaFarmaco.Select(
                                                    vf => new VenditaFarmacoSimpleDto()
                                                    {
                                                        IdVendita = vf.IdVendita,
                                                        DataAcquisto = vf.DataAcquisto,
                                                        NumeroRicetta = vf.NumeroRicetta,
                                                    }
                                                )
                                                .ToList()
                                            : null,
                                })
                                : null
                        ),
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
                    Farmacia = (ICollection<FarmaciaSimpleDto>?)(
                        vendita.Farmacia.Count > 0
                            ? vendita.Farmacia.Select(f => new FarmaciaSimpleDto()
                            {
                                IdFarmaco = f.IdFarmaco,
                                Nome = f.Nome,
                                DittaFornitrice = f.DittaFornitrice,
                                ElencoUsi = f.ElencoUsi,
                                VenditaFarmaco =
                                    f.VenditaFarmaco.Count > 0
                                        ? f
                                            .VenditaFarmaco.Select(
                                                vf => new VenditaFarmacoSimpleDto()
                                                {
                                                    IdVendita = vf.IdVendita,
                                                    DataAcquisto = vf.DataAcquisto,
                                                    NumeroRicetta = vf.NumeroRicetta,
                                                }
                                            )
                                            .ToList()
                                        : null,
                            })
                            : null
                    ),
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
                var newVendita = new VenditaFarmaco()
                {
                    NumeroRicetta = createVenditaFarmaco.NumeroRicetta,
                    DataAcquisto = createVenditaFarmaco.DataAcquisto,
                    AcquirenteId = createVenditaFarmaco.AcquirenteId,
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

        // Put

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
