using CarRentalAPI.DataAccess;
using CarRentalAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
        Task SaveChangesAsync();
    }
    public class CustomerRepository(DataContext _context) : ICustomerRepository
    {
        public async Task<Customer?> GetCustomerByIdAsync(int id) => await _context.Customers.FindAsync(id);
        public async Task<List<Customer>> GetAllCustomersAsync() => await _context.Customers.ToListAsync();
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
