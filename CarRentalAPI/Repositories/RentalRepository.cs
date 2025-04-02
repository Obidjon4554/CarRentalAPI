using CarRentalAPI.DataAccess;
using CarRentalAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repositories
{
    public interface IRentalRepository
    {
        Task Add(Rental rental);

        Task<Rental> GetById(int id);

        Task<IList<Rental>> GetAll();

        Task DeleteAsync(int id, Rental rental);

        void SaveChanges();

        Task SaveChangesAsync();
    }
    public class RentalRepository(DataContext context) : IRentalRepository
    {
        public async Task Add(Rental rental)
        {
            await context.Rentals.AddAsync(rental);
        }

        public async Task<IList<Rental>> GetAll()
        {
            return await context.Rentals.ToListAsync();
        }

        public async Task<Rental> GetById(int id)
        {
            return await context.Rentals.FindAsync(id);
        }

        public async Task DeleteAsync(int id, Rental rental)
        {
            var rentId = await context.Rentals.FindAsync(id);
            if (rentId != null)
                context.Rentals.Remove(rentId);
            await context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
