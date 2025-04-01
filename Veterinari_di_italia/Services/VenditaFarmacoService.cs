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
    }
}
