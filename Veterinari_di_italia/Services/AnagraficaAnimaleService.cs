using Microsoft.EntityFrameworkCore;
using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.Account;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.GestioneRicoveri;
using Veterinari_di_italia.DTOs.TipoAnimale;
using Veterinari_di_italia.DTOs.VenditaFarmaco;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.Services
{
    public class AnagraficaAnimaleService
    {
        private readonly ApplicationDbContext _context;

        public AnagraficaAnimaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> TrySaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<AnagraficaDto>?> GetAllAsync()
        {
            try
            {
                var anagraficheList = await _context
                    .AnagraficaAnimales.Include(a => a.Tipo)
                    .Include(a => a.ProprietarioAnimale)
                    .Include(a => a.visiteVeterinaries)
                    .ThenInclude(vv => vv.Farmaci)
                    .ThenInclude(vf => vf.VenditaFarmaco)
                    .Include(a => a.gestioneRicoveris)
                    .ToListAsync();

                var anagraficheDtoList = anagraficheList
                    .Select(a => new AnagraficaDto()
                    {
                        IdAnimale = a.IdAnimale,
                        DataRegistrazione = a.DataRegistrazione,
                        Nome = a.Nome,
                        TipologiaId = a.TipologiaId,
                        Colore = a.Colore,
                        DataDiNascita = a.DataDiNascita,
                        PresenzaMicrochip = a.PresenzaMicrochip,
                        NumeroMicroChip = a.NumeroMicroChip,
                        ProprietarioId = a.ProprietarioId,
                        Tipo = new TipologiaSimpleDto()
                        {
                            Id = a.Tipo.Id,
                            TipoAnimale = a.Tipo.TipoAnimale,
                        },
                        ProprietarioAnimale =
                            a.ProprietarioAnimale != null
                                ? new UserSimpleDto()
                                {
                                    Id = a.ProprietarioAnimale.Id,
                                    Nome = a.ProprietarioAnimale.Nome,
                                    Cognome = a.ProprietarioAnimale.Cognome,
                                    CodiceFiscale = a.ProprietarioAnimale.CodiceFiscale,
                                    Email = a.ProprietarioAnimale.Email,
                                }
                                : null,
                        VisiteVeterinaries = a
                            .visiteVeterinaries.Select(vv => new VisiteVeterinarieSimpleDto()
                            {
                                Id = vv.Id,
                                DataDellaVisita = vv.DataDellaVisita,
                                EsameObiettivo = vv.EsameObiettivo,
                                Descrizione = vv.Descrizione,
                                Farmaci =
                                    vv.Farmaci.Count() > 0
                                        ? vv
                                            .Farmaci.Select(f => new FarmaciaSimpleDto()
                                            {
                                                IdFarmaco = f.IdFarmaco,
                                                Nome = f.Nome,
                                                DittaFornitrice = f.DittaFornitrice,
                                                ElencoUsi = f.ElencoUsi,
                                                VenditaFarmaco =
                                                    f.VenditaFarmaco.Count() > 0
                                                        ? f
                                                            .VenditaFarmaco.Select(
                                                                vf => new VenditaFarmacoSimpleDto()
                                                                {
                                                                    IdVendita = vf.IdVendita,
                                                                    NumeroRicetta =
                                                                        vf.NumeroRicetta,
                                                                    DataAcquisto = vf.DataAcquisto,
                                                                }
                                                            )
                                                            .ToList()
                                                        : null,
                                            })
                                            .ToList()
                                        : null,
                            })
                            .ToList(),
                        GestioneRicoveris =
                            a.gestioneRicoveris.Count() > 0
                                ? a
                                    .gestioneRicoveris.Select(gr => new GestioneRicoveriSimpleDto()
                                    {
                                        IdRicovero = gr.IdRicovero,
                                        DataRicovero = gr.DataRicovero,
                                        Ricoverato = gr.Ricoverato,
                                        DescrizioneAnimale = gr.DescrizioneAnimale,
                                    })
                                    .ToList()
                                : null,
                    })
                    .ToList();

                return anagraficheDtoList;
            }
            catch
            {
                return null;
            }
        }

        public async Task<AnagraficaDto?> GetByIdAsync(string anagraficaId)
        {
            try
            {
                var anagrafica = await _context
                    .AnagraficaAnimales.Include(a => a.Tipo)
                    .Include(a => a.ProprietarioAnimale)
                    .Include(a => a.visiteVeterinaries)
                    .ThenInclude(vv => vv.Farmaci)
                    .ThenInclude(vf => vf.VenditaFarmaco)
                    .Include(a => a.gestioneRicoveris)
                    .FirstOrDefaultAsync(a => a.IdAnimale.ToString() == anagraficaId);

                if (anagrafica == null)
                {
                    return null;
                }

                var anagraficaFound = new AnagraficaDto()
                {
                    IdAnimale = anagrafica.IdAnimale,
                    DataRegistrazione = anagrafica.DataRegistrazione,
                    Nome = anagrafica.Nome,
                    TipologiaId = anagrafica.TipologiaId,
                    Colore = anagrafica.Colore,
                    DataDiNascita = anagrafica.DataDiNascita,
                    PresenzaMicrochip = anagrafica.PresenzaMicrochip,
                    NumeroMicroChip = anagrafica.NumeroMicroChip,
                    ProprietarioId = anagrafica.ProprietarioId,
                    Tipo = new TipologiaSimpleDto()
                    {
                        Id = anagrafica.Tipo.Id,
                        TipoAnimale = anagrafica.Tipo.TipoAnimale,
                    },
                    ProprietarioAnimale =
                        anagrafica.ProprietarioAnimale != null
                            ? new UserSimpleDto()
                            {
                                Id = anagrafica.ProprietarioAnimale.Id,
                                Nome = anagrafica.ProprietarioAnimale.Nome,
                                Cognome = anagrafica.ProprietarioAnimale.Cognome,
                                CodiceFiscale = anagrafica.ProprietarioAnimale.CodiceFiscale,
                                Email = anagrafica.ProprietarioAnimale.Email,
                            }
                            : null,
                    VisiteVeterinaries = anagrafica
                        .visiteVeterinaries.Select(vv => new VisiteVeterinarieSimpleDto()
                        {
                            Id = vv.Id,
                            DataDellaVisita = vv.DataDellaVisita,
                            EsameObiettivo = vv.EsameObiettivo,
                            Descrizione = vv.Descrizione,
                            Farmaci =
                                vv.Farmaci.Count() > 0
                                    ? vv
                                        .Farmaci.Select(f => new FarmaciaSimpleDto()
                                        {
                                            IdFarmaco = f.IdFarmaco,
                                            Nome = f.Nome,
                                            DittaFornitrice = f.DittaFornitrice,
                                            ElencoUsi = f.ElencoUsi,
                                            VenditaFarmaco =
                                                f.VenditaFarmaco.Count() > 0
                                                    ? f
                                                        .VenditaFarmaco.Select(
                                                            vf => new VenditaFarmacoSimpleDto()
                                                            {
                                                                IdVendita = vf.IdVendita,
                                                                NumeroRicetta = vf.NumeroRicetta,
                                                                DataAcquisto = vf.DataAcquisto,
                                                            }
                                                        )
                                                        .ToList()
                                                    : null,
                                        })
                                        .ToList()
                                    : null,
                        })
                        .ToList(),
                    GestioneRicoveris =
                        anagrafica.gestioneRicoveris.Count() > 0
                            ? anagrafica
                                .gestioneRicoveris.Select(gr => new GestioneRicoveriSimpleDto()
                                {
                                    IdRicovero = gr.IdRicovero,
                                    DataRicovero = gr.DataRicovero,
                                    Ricoverato = gr.Ricoverato,
                                    DescrizioneAnimale = gr.DescrizioneAnimale,
                                })
                                .ToList()
                            : null,
                };

                return anagraficaFound;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateAnagraficaAsync(AnagraficaAnimale newAnagrafica)
        {
            try
            {
                _context.AnagraficaAnimales.Add(newAnagrafica);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAnagraficaAsync(
            AnagraficaAnimale anagrafica,
            string anagraficaId
        )
        {
            try
            {
                var anagraficaFound = await _context.AnagraficaAnimales.FirstOrDefaultAsync(aa =>
                    aa.IdAnimale.ToString() == anagraficaId
                );

                if (anagraficaFound == null)
                {
                    return false;
                }

                anagraficaFound.DataRegistrazione = anagrafica.DataRegistrazione;
                anagraficaFound.Nome = anagrafica.Nome;
                anagraficaFound.TipologiaId = anagrafica.TipologiaId;
                anagraficaFound.Colore = anagrafica.Colore;
                anagraficaFound.DataDiNascita = anagrafica.DataDiNascita;
                anagraficaFound.PresenzaMicrochip = anagrafica.PresenzaMicrochip;
                anagraficaFound.NumeroMicroChip = anagrafica.NumeroMicroChip;
                anagraficaFound.ProprietarioId = anagrafica.ProprietarioId;

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteById(string anagraficaId)
        {
            try
            {
                var anagrafica = await _context.AnagraficaAnimales.FirstOrDefaultAsync(aa =>
                    aa.IdAnimale.ToString() == anagraficaId
                );

                if (anagrafica == null)
                {
                    return false;
                }

                _context.AnagraficaAnimales.Remove(anagrafica);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
