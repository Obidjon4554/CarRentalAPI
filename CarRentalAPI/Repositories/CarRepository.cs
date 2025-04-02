using CarRentalAPI.DataAccess;
using CarRentalAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repositories
{
    public interface ICarRepository
    {
        Task<Car?> GetCarByIdAsync(int id);
        Task<List<Car>> GetAllCarsAsync();
        Task<Car> AddCarAsync(Car car);
        Task DeleteCarAsync(Car car);
        Task SaveChangesAsync();
    }
    public class CarRepository(DataContext _context) : ICarRepository
    {
        public async Task<Car?> GetCarByIdAsync(int id) => await _context.Cars.FindAsync(id);
        public async Task<List<Car>> GetAllCarsAsync() => await _context.Cars.ToListAsync();
        public async Task<Car> AddCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task DeleteCarAsync(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
