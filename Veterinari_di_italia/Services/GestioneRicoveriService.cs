using Veterinari_di_italia.Data;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.Services
{
    public class GestioneRicoveriService
    {
        private readonly ApplicationDbContext _context;

        public GestioneRicoveriService(ApplicationDbContext context)
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

        public async Task<bool> CreateRicoveroAsync(GestioneRicoveri newRicovero)
        {
            try
            {
                _context.GestioneRicoveris.Add(newRicovero);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
