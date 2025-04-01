using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;
using Veterinari_di_italia.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.Farmacia;

namespace Veterinari_di_italia.Services
{
    public class VisiteService
    {
        private readonly ApplicationDbContext _context;

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

                        Anagrafica = a.AnagraficaAnimale.Count > 0 ? a.AnagraficaAnimale.Select(a => new AnagraficaSimpleDTO() 
                        {
                            DataRegistrazione = a.DataRegistrazione,
                            Nome = a.Nome,
                            TipologiaId = a.TipologiaId,
                            Tipo = a.Tipo,
                            Colore = a.Colore,
                            DataDiNascita = a.DataDiNascitaita,
                            PresenzaMicrochip = a.PresenzaMicrochip,
                            NumeroMicroChip = a.NumeroMicroChip,
                            ProprietarioId = a.ProprietarioId,

                        }).ToList()

                        :null,


                    });
                    
            }
            catch (Exception ex)
            {
                
                return new List<VisiteVeterinarieSimpleDto>();
            }
        }


    }

   

}
