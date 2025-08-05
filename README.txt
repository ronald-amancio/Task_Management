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

5. After cloning the repository, it consists of three main project folders
   - TaskManagement
   - TaskManagementAPI
   - TaskManagementSolution
	
         * Open the Main Solution named TaskManagementSolution 
         5a. Running the application thru visual studio
		- It is being already set in the project startup properties, just click Start
		
		API should be running at:
     		http://localhost:5085/swagger/index.html

		UI Should be running at:
     		http://localhost:5268	
 
	 5b. Running the application thru manual or Navigating the Web API
   		- dotnet run --project TaskManagementAPI
     
     		API should be running at:
     		http://localhost:5085/swagger/index.html

	 5c. Run the Blazor Server App thru manual
   		- dotnet run --project TaskManagement

     		UI Should be running at:
     		http://localhost:5268

	 5d. Running Tests
   		- cd TaskManagement.Tests
     	          dotnet test

    		Test Packages:
    		. dotnet add package xunit
    		. dotnet add package Microsoft.AspNetCore.Mvc.Testing
    		. dotnet add package Moq