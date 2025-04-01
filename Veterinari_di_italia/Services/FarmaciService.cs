using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.Farmaci;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.Services
{
    public class FarmaciService
    {
        private readonly ApplicationDbContext _context;
        public FarmaciService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync()
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
       
        public async Task<bool> CreateFarmaci(Farmacia createfarmaci)
        {
            try
            {
                _context.Farmacias.Add(createfarmaci);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }


        public async Task<List<Farmacia>?> GetFarmaci()
        {
            try
            {
                return await _context.Farmacias.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Farmaci?> GetFarmaciById(Guid id)
        {
            try
            {
                var FarmacoEsistente = await _context.Farmacias.FirstOrDefaultAsync(x => x.IdFarmaco == id);

                if (FarmacoEsistente == null)
                {
                    return null;
                }

                var FarmacoDTO = new Farmaci
                {
                    IdFarmaco = FarmacoEsistente.IdFarmaco,
                    Nome = FarmacoEsistente.Nome,
                    DittaFornitrice = FarmacoEsistente.DittaFornitrice,
                    ElencoUsi = FarmacoEsistente.ElencoUsi
                };
                return FarmacoDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteFarmaco(Guid id)
        {
            try
            {
                var FarmacoEsistente = await _context.Farmacias.FirstOrDefaultAsync(x => x.IdFarmaco == id);
                if (FarmacoEsistente == null)
                {
                    return false;
                }
                _context.Farmacias.Remove(FarmacoEsistente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateFarmaco(Guid id, CreateFarmaciDTO createFarmaci)
        {
            try
            {
                var FarmacoEsistente = await _context.Farmacias.FirstOrDefaultAsync(x => x.IdFarmaco == id);
                if (FarmacoEsistente == null)
                {
                    return false;
                }
                FarmacoEsistente.Nome = createFarmaci.Nome;
                FarmacoEsistente.DittaFornitrice = createFarmaci.DittaFornitrice;
                FarmacoEsistente.ElencoUsi = createFarmaci.ElencoUsi;
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
