﻿using System.ComponentModel;
using System.Linq;
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

        public async Task<List<VenditaFarmaco>?> GetVenditeByDateTime(DateTime DataRichiesta)
        {
            try
            {
                var venditeList = await _context
                    .VenditaFarmaco.Include(v => v.Acquirente)
                    .Include(v => v.FarmaciaVenditaFarmaco)
                    .ThenInclude(fvf => fvf.Farmaco)
                    .Where(v => v.DataAcquisto == DataRichiesta)
                    .ToListAsync();

                return venditeList;
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
                var vendita = await _context.VenditaFarmaco
                    .Include(f => f.FarmaciaVenditaFarmaco)
                    .FirstOrDefaultAsync(v =>
                    v.IdVendita.ToString() == venditaId
                );

                if (vendita == null)
                {
                    return false;
                }

                foreach (var e in vendita.FarmaciaVenditaFarmaco)
                {

                    _context.FarmaciaVenditaFarmaco.Remove(e);

                }

                vendita.NumeroRicetta = venditaModificata.NumeroRicetta;
                vendita.DataAcquisto = venditaModificata.DataAcquisto;
                vendita.AcquirenteId = venditaModificata.AcquirenteId;
                vendita.FarmaciaVenditaFarmaco = venditaModificata.FarmaciaVenditaFarmaco;

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

        public async Task<List<Farmacia>?> GetAllFarmaciByFiscalCodeAsync(string codFiscale)
        {
            try
            {
                var venditeList = await _context
                    .VenditaFarmaco.Include(v => v.Acquirente)
                    .Include(v => v.FarmaciaVenditaFarmaco)
                    .ThenInclude(fvf => fvf.Farmaco)
                    .Where(v => v.Acquirente.CodiceFiscale == codFiscale)
                    .ToListAsync();

                if (venditeList.Count == 0)
                {
                    return null;
                }

                var farmaciList = new List<Farmacia>();

                foreach (var vendita in venditeList)
                {
                    foreach (var farmaco in vendita.FarmaciaVenditaFarmaco)
                    {
                        // l'if serve per non far comparire più volte uno stesso farmaco acquistato
                        // se si vuole avere i doppioni rimuovere il controllo if
                        if (!farmaciList.Contains(farmaco.Farmaco))
                        {
                            farmaciList.Add(farmaco.Farmaco);
                        }
                    }
                }

                return farmaciList;
            }
            catch
            {
                return null;
            }
        }
    }
}
