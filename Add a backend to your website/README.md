# API for a resume

This project is an API built using (Minimal API for .NET 6

## Resources

* [.NET SDK 6.0.402+](https://dotnet.microsoft.com/download/dotnet/6.0?WT.mc_id=academic-78652-leestott)
* [Tutorial Build a web API with minimal API, ASP.NET Core, and .NET 6](https://learn.microsoft.com/training/modules/build-web-api-minimal-api/?WT.mc_id=academic-78652-leestott)
* [Documentation: Create a minimal web API with ASP.NET Core](https://learn.microsoft.com/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio?WT.mc_id=academic-78652-leestott)

## Getting Started

To run the Water consumption API, do the following:

- Install EF Core tools

   ```console
   dotnet tool install --global dotnet-ef
   ```

- Apply migrations to database (will create the DB, it's tables and give it initial data)

   ```console
   dotnet ef database update
   ```

- Start the API

   ```console
   dotnet run
   ```

## API

This API has the following endpoints:

- `/`, default route responding with "hello world"
- `/Consumptionsecure`, a route representing a resume, responding with a JSON:

   ```json
   [
   {
     "Id": 1,
     "DateTime" : "",
     "Consumption": 100
   },
   {
     "Id": 2,
     "DateTime" : "",
     "Consumption": 110
   }
   ]
   ```

- `/swagger`, an Open API endpoint that represents the docs of the API

