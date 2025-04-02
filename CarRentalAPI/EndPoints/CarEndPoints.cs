using CarRentalAPI.DataAccess.Entities;
using CarRentalAPI.Repositories;

namespace CarRentalAPI.EndPoints
{
    public static class CarEndPoints
    {
        public static IEndpointRouteBuilder MapCarEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/cars", async (Car car, ICarRepository carRepository) =>
            {
                var newCar = await carRepository.AddCarAsync(car);
                return Results.Created($"/cars/{newCar.Id}", newCar);
            });

            app.MapGet("/cars", async (ICarRepository carRepository) =>
            {
                var cars = await carRepository.GetAllCarsAsync();
                return Results.Ok(cars);
            });

            app.MapGet("/cars/{id}", async (int id, ICarRepository carRepository) =>
            {
                var car = await carRepository.GetCarByIdAsync(id);
                return car is not null ? Results.Ok(car) : Results.NotFound();
            });

            app.MapDelete("/cars/{id}", async (int id, ICarRepository carRepository) =>
            {
                var car = await carRepository.GetCarByIdAsync(id);
                if (car is null) return Results.NotFound();
                await carRepository.DeleteCarAsync(car);
                return Results.NoContent();
            });
            return app;
        }
    }
}
