using Microsoft.EntityFrameworkCore;
using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.AnagraficaAnimale;
using Veterinari_di_italia.DTOs.TipoAnimale;
using Veterinari_di_italia.Models;

namespace Veterinari_di_italia.Services
{
    public class TipologiaAnimaliService
    {
        private readonly ApplicationDbContext _context;

        public TipologiaAnimaliService(ApplicationDbContext context)
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

        public async Task<bool> CreateTipologiaAsync(TipologiaAnimale tipologia)
        {
            try
            {
                _context.TipologiaAnimales.Add(tipologia);

                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<GetTipoAnimaleRequestDTO>?> GetAllTipoAnimale()
        {
            try
            {
                var tipologia = await _context
               .TipologiaAnimales.Include(aa => aa.AnagraficaAnimale)
               .ToListAsync();
                var tipologiaDTO = tipologia
                    .Select(x => new GetTipoAnimaleRequestDTO()
                    {
                        TipoAnimale = x.TipoAnimale,
                        AnagraficaAnimale = x.AnagraficaAnimale.Count > 0 ? x.AnagraficaAnimale.Select(aa => new AnagraficaSimpleDTO()
                        {
                            Nome = aa.Nome,
                            DataRegistrazione = aa.DataRegistrazione,
                            Colore = aa.Colore,
                            TipologiaId = aa.TipologiaId,
                            DataDiNascita = aa.DataDiNascita,
                            PresenzaMicrochip = aa.PresenzaMicrochip,
                            NumeroMicroChip = aa.NumeroMicroChip,
                            ProprietarioId = aa.ProprietarioId,
                        }).ToList()
                        : null,
                    }).ToList();

                return tipologiaDTO;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public async Task<GetTipoAnimaleRequestDTO?> GetTipoAnimaleById(int id)
        {
            try
            {

                var tipologia = await _context
               .TipologiaAnimales.Include(aa => aa.AnagraficaAnimale)
               .FirstOrDefaultAsync(x => x.Id == id);
                if (tipologia == null)
                {
                    return null;
                }
                var tipologiaDTO = new GetTipoAnimaleRequestDTO()
                {
                    TipoAnimale = tipologia.TipoAnimale,
                    AnagraficaAnimale = tipologia.AnagraficaAnimale.Count > 0 ? tipologia.AnagraficaAnimale.Select(aa => new AnagraficaSimpleDTO()
                    {
                        Nome = aa.Nome,
                        DataRegistrazione = aa.DataRegistrazione,
                        Colore = aa.Colore,
                        TipologiaId = aa.TipologiaId,
                        DataDiNascita = aa.DataDiNascita,
                        PresenzaMicrochip = aa.PresenzaMicrochip,
                        NumeroMicroChip = aa.NumeroMicroChip,
                        ProprietarioId = aa.ProprietarioId,
                    }).ToList()
                    : null,
                };
                return tipologiaDTO;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<bool> UpdateTipologiaAsync(int id, TipologiaAnimale tipologia)
        {
            try
            {
                var tipo = await _context.TipologiaAnimales.FirstOrDefaultAsync(x => x.Id == id);
                tipo.TipoAnimale = tipologia.TipoAnimale;
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTipologiaAsync(int id)
        {
            try
            {
                var tipologia = await _context.TipologiaAnimales.FirstOrDefaultAsync(x => x.Id == id);
                if (tipologia == null)
                {
                    return false;
                }
                _context.TipologiaAnimales.Remove(tipologia);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
