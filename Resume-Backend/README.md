# API for a resume

This project is an API built using Minimal API for .NET 6.

## What you will need 

* [.NET SDK 6.0.402+](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Getting Started

To run the resume API, do the following:

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
- `/resume`, a route representing a resume, responding with a JSON:

   ```json
   {
     "Name": "",s
     "Educations": [],
     "Skills": [],
     "Experiences": []
   }
   ```

- `/swagger`, an Open API endpoint that represents the docs of the API

