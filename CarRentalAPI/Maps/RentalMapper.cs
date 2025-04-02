using CarRentalAPI.DataAccess.Entities;
using CarRentalAPI.Dtos;
using Riok.Mapperly.Abstractions;

namespace CarRentalAPI.Maps
{
    [Mapper]
    public partial class RentalMapper
    {
        public partial Rental CreateRentalDtoToRental(CreateRentalDto dto);

        public  RentalDto RentalToDto(Rental rental, Car car, Customer customer)
        {
            return new RentalDto
            {
                Id = rental.Id,
                CarInfo = $"{car.Make} {car.Model} ({car.Year})",  // Concatenate car details
                CustomerName = customer.FullName,                   // Customer's full name
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                TotalPrice = rental.TotalPrice
            };
        }

    }
}
