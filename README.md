# Welcome to the Baby Tracker App
A web application that you can use to track your newborn's bowel, eating, and sleeping habits.
## News and Updates
    12-Feb-2020 "Added the models Diaper, Feeding, Growth, Infant, Medication (no validations yet)"
    03-Feb-2020 "Initialized the project."

## Software Pre-requisites
- [Install Visual Studio Community 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16)
- [Install .NET SDK 5.0.102](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.102-windows-x64-installer)
- [Install SQLServer Express Edition](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)

##  Install required Global Tools
### Enter the following commands within the BabyTracker project folder
    dotnet tool install --global dotnet-ef
    dotnet tool install --global Microsoft.Web.LibraryManager.Cli

## Run the project on your local host
### Enter the following commands within the BabyTracker project folder
    dotnet build
    dotnet run

    
## Project Initialization
*The following commands were ran for initializing the project, not necessary to run this commands when you clone/pull the project.*

## Install required NuGet Packages
### Enter the following commands within the BabyTracker project folder
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
    dotnet add package Westwind.AspNetCore.LiveReload

## Sync your SqlServer database
### Enter the following commands within the BabyTracker project folder
    dotnet ef database drop --force
    dotnet ef migrations add AfterClone
    dotnet ef database update

## Install Bootstrap
### Enter the following commands within the BabyTracker project folder
    libman init -p cdnjs
    libman install twitter-bootstrap@4.6.0 -d wwwroot/lib/twitter-bootstrap

