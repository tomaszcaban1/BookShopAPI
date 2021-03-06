# BookShopAPI

> A .Net 5 implementation of a really simple bookshop api management system. Project was created for learning programming in ASP.NET Core for .NET 5, Entity Framework Core 5 and publish it to Azure portal.
> Live Swagger UI [_here_](https://bookshop-api-app.azurewebsites.net/swagger/index.html). 

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [api request examples](#api-request-examples)
* [Programming tricks](#programming-tricks)
* [Contact](#contact)

## General Information
- My goal was to design and meet with the philosophies of creating a RESTful Web API.

## Technologies Used
- .NET 5.0 
- Entity Framework Core 5.0.6
- AutoMapper.Extensions.Microsoft.DependencyInjection 8.1.1
- FluentValidation.AspNetCore 10.1.0
- Microsoft.AspNetCore.StaticFiles 2.2.0
- NLog.Web.AspNetCore 4.12.0
- washbuckle.AspNetCore 6.1.4
- MS SQL v2014 (Azure)

## api request examples e.g. https://reqbin.com/
- GET:
  - https://bookshop-api-app.azurewebsites.net/api/SQL/BookShop/1/booksql/?PageNumber=1&SearchAuthor=love&SortBy=Price&PageSize=10&SortDirection=ASC
  - https://bookshop-api-app.azurewebsites.net/api/BookShop/1/book/?PageNumber=1&SearchAuthor=love&SortBy=Price&PageSize=10&SortDirection=ASC
  - https://bookshop-api-app.azurewebsites.net/api/BookShop/2/Book/4006
  - https://bookshop-api-app.azurewebsites.net/api/BookShop/2
- POST:
  - https://bookshop-api-app.azurewebsites.net/api/BookShop/
  body JSON:
{
    "Name": "Nowa księgarnia TEST AAA",
    "Description": "Nowa księgarnia 10",
    "ContactEmail": "nowaksiegarnia4@ccc.pl",
    "ContactNumber1": "666-999-555",
    "ContactNumber2": "333-444-333",
    "City": "Warszawa",
    "Street": "Plac Niepodległości",
    "StreetNumber": 10,
    "PostalCode": "97-330"
}
- PUT:
  - https://bookshop-api-app.azurewebsites.net/api/BookShop/2/Book/4006
   body JSON:
{
    "description": "Comedy NEW",
    "price": 100
}
- DELETE:
  - https://bookshop-api-app.azurewebsites.net/api/BookShop/2/Book/502

## Programming tricks
- Low level of coupling, modules depend on abstractions (interfaces). Business logic of controllers are located in services which are registered into the dependency injection container.
- dto models were used to communicate with the user (mapping by AutoMapper). 
- Added middleware to catch an exceptions (e.g. created NotFoundException)
- nlog is used to log information about application operation.
- Added models validator (FluentValidation)
- Added support for static files 
- Added pagination to some GET requests (plus extra extension method OrderBy/OrderbyDescending to simplify LINQ command)
- Used static Guard class as a defensing code approach
- Added Swagger endpoint
- One http request run SQL procedure to get data

## Acknowledgements
- This project was based on [pluralsight ASP.NET Core path](https://app.pluralsight.com/paths/skills/aspnet-core).

## Contact
Created by Tomasz.Caban@gmail.com - feel free to contact me!
