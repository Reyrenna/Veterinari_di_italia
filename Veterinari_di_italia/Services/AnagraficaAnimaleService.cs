using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AnagraficaDto>?> GetAllAsync()
        {
            try
            {
                var anagraficheList = await _context.AnagraficaAnimales.ToListAsync();

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
                        // Tipo
                        // Proprietario
                        // visiteVeterinarire (lista)
                        // gestione ricoveri (lista)
                    })
                    .ToList();

                return anagraficheDtoList;
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
