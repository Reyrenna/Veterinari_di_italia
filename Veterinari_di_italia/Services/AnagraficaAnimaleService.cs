using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
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
    }
}
