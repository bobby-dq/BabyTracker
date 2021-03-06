# Welcome to the Baby Tracker App
A web application that you can use to track your newborn's bowel, eating, and sleeping habits. You can visit the website [here](https://babytracker.azurewebsites.net/) and sign up for free!
This web application utilizes the CRUD operations of Entity Framework Core, ASP.NET Core MVC, ASP.NET Core Razor Pages, Tailwind CSS, and MSSSQL Server. It also uses Identity's roles and users functionality for administration purposes.

## Technologies Used
 - ASP.NET Core 5.0
 - Tailwind CSS
 - Azure SQL Server and Database
 - Azure App Service

## Here are a few snapshots of the website.
### Frontpage
![Frontpage](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Frontpage.JPG)
### Infant List
![Infant List](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Infant%20%20Lists.JPG)
### Infant Dashboard
![Dashboard](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/dashboard.JPG)
### Create
![Create](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Create.JPG)
### Edit
![Edit](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Edit.JPG)
### Delete
![Delete](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Delete.JPG)
### Registration (its free!)
![Register](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Register%20pages.JPG)
### Login 
![Login](https://github.com/bobby-dq/BabyTracker/blob/main/README%20Screenshots/Login.JPG)

## News and Updates
    08-Mar-2021 "Published to azure. Visit the following link https://babytracker.azurewebsites.net/"
    07-Mar-2021 "Updated the editor and index pages for the entity models, as well as a infant dashboard."
    02-Mar-2021 "Created CRUD operations for entity models, implemented users and roles from AspNet Idenitity, and implemented AuthN and AuthZ on controllers and razor pages."
    16-Feb-2021 "Started the model property validations, as well as the infant view model factory."
    13-Feb-2021 "Migrated the database seed data and initialized the database connection string."
    12-Feb-2021 "Added the models Diaper, Feeding, Growth, Infant, Medication (no validations yet)"
    03-Feb-2021 "Initialized the project."

## Software Pre-requisites
- [Install Visual Studio Community 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
- [Install .NET SDK 5.0.102](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer)
- [Install SQLServer Express Edition](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
- [Download and Install Node.js](https://nodejs.org/en/)

##  Install required Global Tools
### Enter the following commands within the BabyTracker project folder
    dotnet tool install --global dotnet-ef
    dotnet tool install --global Microsoft.Web.LibraryManager.Cli

## Sync your SqlServer database
    *Before you enter the following commands, please delete the 'migrations' folder and all of its contents*
### Enter the following commands within the BabyTracker project folder
    dotnet ef migrations add init_BabyTrackerContext --context BabyTrackerContext
    dotnet ef migrations add init_IdentityContext --context IdentityContext
    dotnet ef database drop --force --context BabyTrackerContext
    dotnet ef database drop --force --context IdentityContext
    dotnet ef database update --context BabyTrackerContext
    dotnet ef database update --context IdentityContext

## Run the project on your local host
### Enter the following commands within the BabyTracker project folder
    dotnet build
    dotnet run

    
## Project Initialization
*The following commands were ran for initializing the project, not necessary to run these commands when you clone/pull the project.*

## Install required NuGet Packages
### Enter the following commands within the BabyTracker project folder
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation




