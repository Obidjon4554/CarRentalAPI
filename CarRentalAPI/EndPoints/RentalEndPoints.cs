using CarRentalAPI.Dtos;
using CarRentalAPI.Maps;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.EndPoints
{
    public static class RentalEndPoints
    {
        public static IEndpointRouteBuilder MapRentalEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/rentals/add", async (CreateRentalDto dto,
                                               IRentalRepository rentalRepository,
                                               ICarRepository carRepository,
                                               ICustomerRepository customerRepository) =>
            {
                var car = await carRepository.GetCarByIdAsync(dto.CarId);
                var customer = await customerRepository.GetCustomerByIdAsync(dto.CustomerId);

                if (car == null || customer == null || !car.IsAvailable)
                    return Results.BadRequest("Invalid car or customer");

                var rentalMapper = new RentalMapper();
                var rental = rentalMapper.CreateRentalDtoToRental(dto);

                rental.TotalPrice = (dto.EndDate - dto.StartDate).Days * car.DailyRate;
                car.IsAvailable = false;

                await rentalRepository.Add(rental);

                var rentalDto = rentalMapper.RentalToDto(rental, car, customer);
                await rentalRepository.SaveChangesAsync();

                return Results.Created($"/rentals/{rental.Id}", rentalDto);
            })
                .WithName("CreateRental")
                .WithOpenApi();

            app.MapGet("/rentals/", async (IRentalRepository rentalRepository,
                                               ICarRepository carRepository,
                                               ICustomerRepository customerRepository) =>
            {
                var rentals = await rentalRepository.GetAll();
                var rentalMapper = new RentalMapper();
                var rentalDtos = new List<RentalDto>();
                foreach (var rental in rentals)
                {
                    var car = await carRepository.GetCarByIdAsync(rental.CarId);
                    var customer = await customerRepository.GetCustomerByIdAsync(rental.CustomerId);
                    var rentalDto = rentalMapper.RentalToDto(rental, car, customer);
                    rentalDtos.Add(rentalDto);
                }
                return Results.Ok(rentalDtos);
            })
                .WithName("GetAllRentals")
                .WithOpenApi();


            app.MapGet("/rentals/{id}", async (int id, IRentalRepository rentalRepository,
                                               ICarRepository carRepository,
                                               ICustomerRepository customerRepository) =>
            {
                var rental = await rentalRepository.GetById(id);


                if (rental == null)
                {
                    return Results.NotFound();
                }

                var car = await carRepository.GetCarByIdAsync(rental.CarId);
                var customer = await customerRepository.GetCustomerByIdAsync(rental.CustomerId);
                var rentalMapper = new RentalMapper();
                var rentalDto = rentalMapper.RentalToDto(rental, car, customer);
                return Results.Ok(rentalDto);
            })
                .WithName("GetRentalById")
                .WithOpenApi();


            app.MapDelete("/rentals/{id}", async (int id, IRentalRepository rentalRepository,
                                                          ICarRepository carRepository,
                                                          ICustomerRepository customerRepository) =>
            {
                var rental = await rentalRepository.GetById(id);
                if (rental == null) 
                    return Results.NotFound();

                var car = await carRepository.GetCarByIdAsync(rental.CarId);
                if (car != null)
                    car.IsAvailable = true;

                await rentalRepository.DeleteAsync(id,rental);
                return Results.NoContent();
            });

            return app;
        }
    }
}
