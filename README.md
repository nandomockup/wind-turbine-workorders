# Wind Turbine Work Orders API

This is a simple ASP.NET Core Web API that provides mock work order data for wind turbines. It includes Swagger/OpenAPI documentation for easy testing and exploration.

## Features
- **GET /api/WorkOrders**: Retrieve all 15 mock work orders
- **GET /api/WorkOrders/{workOrderNumber}**: Retrieve a specific work order by its number
- Built with .NET 8 and ASP.NET Core
- Swagger UI enabled for API documentation

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Run the API
```sh
dotnet run --project WindTurbineWorkOrders
```

The API will be available at `http://localhost:5114` (or the port shown in your terminal).

Swagger UI: `http://localhost:5114/swagger`

## Project Structure
- `WindTurbineWorkOrders/Controllers/WorkOrdersController.cs`: Main API endpoints
- `WindTurbineWorkOrders/Program.cs`: App configuration

## License
MIT
