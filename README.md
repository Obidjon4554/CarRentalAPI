# CarRentalAPI
Car Rental API
Welcome to the Car Rental API! This API allows you to manage car rentals by creating rental records, checking available cars, and retrieving rental details.

Features
Create a new rental
View all rentals
View a rental by ID
Delete a rental

How to Use the API
1. Run the Application
Before using the API, make sure you have the following installed:
.NET SDK: Download it from here if you haven't installed it yet.

To run the API locally:
Open your terminal/command prompt.
Navigate to the project folder.

Run the following command:
dotnet run
This will start the application.

2. Create a Rental
To create a new rental, send a POST request to /rentals with the following data:
Request body example (JSON):
{
  "CarId": 1,
  "CustomerId": 1,
  "StartDate": "2025-04-10T10:00:00",
  "EndDate": "2025-04-15T10:00:00"
}

CarId: ID of the car you want to rent.
CustomerId: ID of the customer renting the car.
StartDate: The rental start date and time.
EndDate: The rental end date and time.

Response (Success):
{
  "Id": 1,
  "CarInfo": "Toyota Camry 2020",
  "CustomerName": "John Doe",
  "StartDate": "2025-04-10T10:00:00",
  "EndDate": "2025-04-15T10:00:00",
  "TotalPrice": 250.00
}

CarInfo: The make, model, and year of the car (e.g., "Toyota Camry 2020").
CustomerName: The name of the customer renting the car (e.g., "John Doe").
TotalPrice: The total price for the rental, calculated based on the days rented.

3. Get All Rentals
To see all rentals, send a GET request to /rentals.

Response example:
[
  {
    "Id": 1,
    "CarInfo": "Toyota Camry 2020",
    "CustomerName": "John Doe",
    "StartDate": "2025-04-10T10:00:00",
    "EndDate": "2025-04-15T10:00:00",
    "TotalPrice": 250.00
  },
  {
    "Id": 2,
    "CarInfo": "Honda Civic 2019",
    "CustomerName": "Jane Smith",
    "StartDate": "2025-04-12T10:00:00",
    "EndDate": "2025-04-17T10:00:00",
    "TotalPrice": 225.00
  }
]

4. Get a Rental by ID
To get details of a specific rental, send a GET request to /rentals/{id}, where {id} is the rental ID.

Example:
GET /rentals/1
Response example:
{
  "Id": 1,
  "CarInfo": "Toyota Camry 2020",
  "CustomerName": "John Doe",
  "StartDate": "2025-04-10T10:00:00",
  "EndDate": "2025-04-15T10:00:00",
  "TotalPrice": 250.00
}

5. Delete a Rental
To delete a rental, send a DELETE request to /rentals/{id}, where {id} is the rental ID you want to remove.

Example:
DELETE /rentals/1
Response:
No content (204): The rental was successfully deleted.

API Endpoints
1. Create a Rental
POST /rentals
Request body: CarId, CustomerId, StartDate, EndDate (as shown above)
Response: Rental details with CarInfo, CustomerName, TotalPrice

2. Get All Rentals
GET /rentals
Response: List of all rentals

3. Get Rental by ID
GET /rentals/{id}
Response: Rental details for the specific ID

4. Delete a Rental
DELETE /rentals/{id}
Response: No content (204)

Additional Notes
When a rental is created, the car is marked as unavailable.
You cannot rent a car if it’s already rented out (i.e., IsAvailable = false).
Feel free to test the API using Postman or your preferred API testing tool!
