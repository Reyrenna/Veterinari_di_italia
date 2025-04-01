using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;
using Veterinari_di_italia.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.Farmacia;
using Veterinari_di_italia.DTOs.TipoAnimale;

namespace Veterinari_di_italia.Services
{
    public class VisiteService
    {
        private readonly ApplicationDbContext _context;

        public VisiteService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> Saveasync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> CreateVisita(VisiteVeterinarie visite)
        {
            try
            {

                _context.VisiteVeterinaries.Add(visite);

                return await Saveasync();

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<VisiteVeterinarieSimpleDto>?> GetAllAsync()
        {
            try
            {
                var Visite = await _context
                     .VisiteVeterinaries.Include(a => a.AnagraficaAnimale)
                     .Include(a => a.Farmaci)
                     .ToListAsync();

                var VisiteListe = Visite
                    .Select(a => new VisiteVeterinarieSimpleDto()
                    {
                        Id = a.Id,
                        DataDellaVisita = a.DataDellaVisita,
                        EsameObiettivo = a.EsameObiettivo,
                        Descrizione = a.Descrizione,

                        Farmaci = a.Farmaci.Count > 0 ? a.Farmaci.Select(a => new FarmaciaSimpleDto()
                        {
                            IdFarmaco = a.IdFarmaco,
                            Nome = a.Nome,
                            DittaFornitrice = a.DittaFornitrice,
                            ElencoUsi = a.ElencoUsi,

                        }).ToList()

                        : null,

                        Anagrafica = new AnagraficaSimpleDTO()
                        {
                            DataRegistrazione = a.AnagraficaAnimale.DataRegistrazione,
                            Nome = a.AnagraficaAnimale.Nome,
                            TipologiaId = a.AnagraficaAnimale.TipologiaId,
                            Tipo = new TipologiaSimpleDto()
                            {
                                Id = a.AnagraficaAnimale.Tipo.Id,
                                TipoAnimale = a.AnagraficaAnimale.Tipo.TipoAnimale,
                            },
                            Colore = a.AnagraficaAnimale.Colore,
                            DataDiNascita = a.AnagraficaAnimale.DataDiNascita,
                            PresenzaMicrochip = a.AnagraficaAnimale.PresenzaMicrochip,
                            NumeroMicroChip = a.AnagraficaAnimale.NumeroMicroChip,
                            ProprietarioId = a.AnagraficaAnimale.ProprietarioId,

                        },


                    }).ToList();
                return VisiteListe;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<VisiteVeterinarieSimpleDto?> GetVisitaById(int id)
        {
            try
            {
                var Visita = await _context
                    .VisiteVeterinaries.Include(a => a.AnagraficaAnimale)
                    .Include(a => a.Farmaci)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (Visita == null)
                {
                    return null;
                }
                var VisitaDto = new VisiteVeterinarieSimpleDto()
                {
                    Id = Visita.Id,
                    DataDellaVisita = Visita.DataDellaVisita,
                    EsameObiettivo = Visita.EsameObiettivo,
                    Descrizione = Visita.Descrizione,
                    Farmaci = Visita.Farmaci.Count > 0 ? Visita.Farmaci.Select(a => new FarmaciaSimpleDto()
                    {
                        IdFarmaco = a.IdFarmaco,
                        Nome = a.Nome,
                        DittaFornitrice = a.DittaFornitrice,
                        ElencoUsi = a.ElencoUsi,
                    }).ToList()
                    : null,
                    Anagrafica = new AnagraficaSimpleDTO()
                    {
                        DataRegistrazione = Visita.AnagraficaAnimale.DataRegistrazione,
                        Nome = Visita.AnagraficaAnimale.Nome,
                        TipologiaId = Visita.AnagraficaAnimale.TipologiaId,
                        Tipo = new TipologiaSimpleDto()
                        {
                            Id = Visita.AnagraficaAnimale.Tipo.Id,
                            TipoAnimale = Visita.AnagraficaAnimale.Tipo.TipoAnimale,
                        },
                        Colore = Visita.AnagraficaAnimale.Colore,
                        DataDiNascita = Visita.AnagraficaAnimale.DataDiNascita,
                        PresenzaMicrochip = Visita.AnagraficaAnimale.PresenzaMicrochip,
                        NumeroMicroChip = Visita.AnagraficaAnimale.NumeroMicroChip,
                        ProprietarioId = Visita.AnagraficaAnimale.ProprietarioId,
                    },
                };
                return VisitaDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> EditVisite(VisiteVeterinarie visiteVeterinarie, int id)
        {
            try
            {
                var Visita = await _context.VisiteVeterinaries.FirstOrDefaultAsync(a => a.Id == id);
                if (Visita == null)
                {
                    return false;
                }
                Visita.DataDellaVisita = visiteVeterinarie.DataDellaVisita;
                Visita.EsameObiettivo = visiteVeterinarie.EsameObiettivo;
                Visita.Descrizione = visiteVeterinarie.Descrizione;
                Visita.Farmaci = visiteVeterinarie.Farmaci;
                Visita.AnagraficaAnimale = visiteVeterinarie.AnagraficaAnimale;

                return await Saveasync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteVisita(int id)
        {
            try
            {
                var Visita = await _context.VisiteVeterinaries.FirstOrDefaultAsync(a => a.Id == id);
                if (Visita == null)
                {
                    return false;
                }
                _context.VisiteVeterinaries.Remove(Visita);
                return await Saveasync();
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
   

}
