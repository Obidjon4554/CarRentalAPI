using CarRentalAPI.DataAccess.Entities;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.EndPoints
{
    public static class CustomerEndPoints
    {
        public static IEndpointRouteBuilder MapCustomerEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/customers", async (Customer customer, ICustomerRepository customerRepository) =>
            {
                var newCustomer = await customerRepository.AddCustomerAsync(customer);
                return Results.Created($"/customers/{newCustomer.Id}", newCustomer);
            });

            app.MapGet("/customers", async (ICustomerRepository customerRepository) =>
            {
                var customers = await customerRepository.GetAllCustomersAsync();
                return Results.Ok(customers);
            });

            app.MapGet("/customers/{id}", async (int id, ICustomerRepository customerRepository) =>
            {
                var customer = await customerRepository.GetCustomerByIdAsync(id);
                return customer is not null ? Results.Ok(customer) : Results.NotFound();
            });

            app.MapDelete("/customers/{id}", async (int id, ICustomerRepository customerRepository) =>
            {
                var customer = await customerRepository.GetCustomerByIdAsync(id);
                if (customer is null) return Results.NotFound();
                await customerRepository.DeleteCustomerAsync(customer);
                return Results.NoContent();
            });
            return app;
        }
    }
}
