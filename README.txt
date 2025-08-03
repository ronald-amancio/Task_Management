Task Management Solution

1. Project Overview
  - A full-stack Blazor Server + ASP.NET Core Web API application to manage tasks with CRUD functionality, validation, pagination, and responsive UI.

2. Tech Stack
  - Blazor Server (.NET 8)
  - ASP.NET Core Web API (.NET 8)
  - Entity Framework Core (InMemory)
  - Bootstrap 5
  - xUnit, Moq for testing

3. Prerequisites

  - .NET 8 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - Visual Studio 2022+ or Visual Studio Code
  - Git

4. Clone the Repository
   - git clone https://github.com/ronald-amancio/Task_Management.git
     cd TaskManagementSolution

5. Run the Web API
   - dotnet run --project TaskManagementAPI
     
     API should be running at:
     http://localhost:5085/swagger/index.html

6. Run the Blazor Server App
   - dotnet run --project TaskManagement

     UI Should be running at:
     http://localhost:5268

7. Running Tests
   - cd TaskManagement.Tests
     dotnet test

    Test Packages:
    . dotnet add package xunit
    . dotnet add package Microsoft.AspNetCore.Mvc.Testing
    . dotnet add package Moq