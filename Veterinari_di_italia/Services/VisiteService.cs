using Veterinari_di_italia.Data;
using Veterinari_di_italia.DTOs.VisiteVeterinarie;
using Veterinari_di_italia.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

    }

   

}
