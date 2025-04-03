using Microsoft.EntityFrameworkCore;
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

        public async Task<List<GestioneRicoveri>?> GetAllRicoveriAsync()
        {
            try
            {
                var ricoveriList = await _context
                    .GestioneRicoveris.Include(r => r.AnagraficaAnimale)
                    .ThenInclude(a => a.Tipo)
                    .Include(r => r.AnagraficaAnimale)
                    .ThenInclude(a => a.ProprietarioAnimale)
                    .ToListAsync();

                return ricoveriList;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<GestioneRicoveri>?> GetAllRicoveriAttiviAsync()
        {
            try
            {
                var ricoveriList = await _context
                    .GestioneRicoveris.Include(r => r.AnagraficaAnimale)
                    .ThenInclude(a => a.Tipo)
                    .Include(r => r.AnagraficaAnimale)
                    .ThenInclude(a => a.ProprietarioAnimale)
                    .Where(r => r.Ricoverato == true)
                    .ToListAsync();

                return ricoveriList;
            }
            catch
            {
                return null;
            }
        }

        public async Task<GestioneRicoveri?> GetRicoveroByIdAsync(string ricoveroId)
        {
            try
            {
                var ricovero = await _context
                    .GestioneRicoveris.Include(r => r.AnagraficaAnimale)
                    .ThenInclude(a => a.Tipo)
                    .Include(r => r.AnagraficaAnimale)
                    .ThenInclude(a => a.ProprietarioAnimale)
                    .FirstOrDefaultAsync(r => r.IdRicovero.ToString() == ricoveroId);

                return ricovero;
            }
            catch
            {
                return null;
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

        public async Task<bool> EditRicoveroByIdAsync(
            GestioneRicoveri ricoveroModified,
            string ricoveroId
        )
        {
            try
            {
                var ricovero = await _context.GestioneRicoveris.FirstOrDefaultAsync(r =>
                    r.IdRicovero.ToString() == ricoveroId
                );

                if (ricovero == null)
                {
                    return false;
                }

                ricovero.DataRicovero = ricoveroModified.DataRicovero;
                ricovero.Ricoverato = ricoveroModified.Ricoverato;
                ricovero.DescrizioneAnimale = ricoveroModified.DescrizioneAnimale;
                ricovero.IdAnimale = ricoveroModified.IdAnimale;

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteById(string ricoveroId)
        {
            try
            {
                var ricovero = await _context.GestioneRicoveris.FirstOrDefaultAsync(r =>
                    r.IdRicovero.ToString() == ricoveroId
                );

                if (ricovero == null)
                {
                    return false;
                }

                _context.GestioneRicoveris.Remove(ricovero);

                return await TrySaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<AnagraficaAnimale?> RicercaPerMicroChip(string NumeroMicroChip)
        {
            try
            {
                var ricerca = await _context.AnagraficaAnimales
                    .Include(x => x.Tipo)
                    .Include(x => x.ProprietarioAnimale)
                    .Include (x => x.gestioneRicoveris)
                    .FirstOrDefaultAsync(a =>
                a.NumeroMicroChip == NumeroMicroChip);

                if (ricerca == null)
                {
                    return null;
                }

                return ricerca;
               
            }

            catch
            {
                return null;
            }

        }
    }
}
