using Microsoft.EntityFrameworkCore;
using Veterinari_di_italia.Data;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.Services
{
    public class VenditaFarmacoService
    {
        private readonly ApplicationDbContext _context;

        public VenditaFarmacoService(ApplicationDbContext context)
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

        public async Task<List<VenditaFarmaco>?> GetAllVenditeAsync()
        {
            try
            {
                var venditeList = await _context
                    .VenditaFarmaco.Include(v => v.Acquirente)
                    .Include(v => v.FarmaciaVenditaFarmaco)
                    .ThenInclude(fvf => fvf.Farmaco)
                    .ToListAsync();

                return venditeList;
            }
            catch
            {
                return null;
            }
        }

        public async Task<VenditaFarmaco?> GetVenditaByIdAsync(string venditaId)
        {
            try
            {
                var vendita = await _context
                    .VenditaFarmaco.Include(v => v.Acquirente)
                    .Include(v => v.FarmaciaVenditaFarmaco)
                    .ThenInclude(fvf => fvf.Farmaco)
                    .FirstOrDefaultAsync(v => v.IdVendita.ToString() == venditaId);

                return vendita;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> CreateVenditaFarmacoAsync(VenditaFarmaco newVendita)
        {
            try
            {
                _context.VenditaFarmaco.Add(newVendita);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditVenditaByIdAsync(
            VenditaFarmaco venditaModificata,
            string venditaId
        )
        {
            try
            {
                var vendita = await _context.VenditaFarmaco.FirstOrDefaultAsync(v =>
                    v.IdVendita.ToString() == venditaId
                );

                if (vendita == null)
                {
                    return false;
                }

                vendita.NumeroRicetta = venditaModificata.NumeroRicetta;
                vendita.DataAcquisto = venditaModificata.DataAcquisto;
                vendita.AcquirenteId = venditaModificata.AcquirenteId;

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(string venditaId)
        {
            try
            {
                var vendita = await _context.VenditaFarmaco.FirstOrDefaultAsync(v =>
                    v.IdVendita.ToString() == venditaId
                );

                if (vendita == null)
                {
                    return false;
                }

                _context.VenditaFarmaco.Remove(vendita);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
