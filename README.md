# DadsCollections

A mini e-commerce App with C#.

View Application on [Azure](https://naamp-twitter-app.herokuapp.com/) (Work in progress)

<img src="" />

<img src="" />

## Summary

A simple e-commerce application where the shopper can view products, add product(s) to the cart, and create a purcahse order on the web application (Razor Pages). While on the WPF, the vendor can look up a purchase order, and modify them as needed. Also, the vendor can search for and create new products. 

From my previous console application, I’m taking this C# app to a whole new level. I learn a ton building this app, from front end to back end to DB and how to work with class library and OOP, organize files and folder. I enjoyed the process and love how I put all the pieces together. :) 


## App flow/Functionality: 

1. Razor Pages
    - Once an item has been added to the cart, HttpContext.Session will be initiated 
    and the item in the cart will be saved as a session value. 
    So that the cart value persists whenever the page gets refreshed.
    - Every time user modifies the cart, the session value gets updated.
    - As the user checks out the order, they would need to put in their first and last name and email, 
    and these will be saved to the DB.
    - Once the order has been placed, the order will be saved to the DB and the cart value in session storage will be removed. 

2. WPF
    - The vendor can look up orders by email. 
    They can update the order status to either completed or canceled.
    - The vendor can look up products and create new products. The new products will be saved to the DB.


## Built With

- Environment - ASP.NET
- Frontend - [Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio) & [WPF](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-wpf?view=vs-2022)
- Backend - [.NET Core Class Library](https://learn.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio?pivots=dotnet-7-0)
    - Models 
    -	Data Access class (Business Logic – UI talks directly to this class)
    -	DB Access class with Dapper (Query data from and Save data to DB)
- Database
    - Server: SQL
    - Class Library with Data tables & Stored Procedures
- Deployment
    - [Azure](https://azure.microsoft.com/)




## Author

- Naam Pondpat - _Full Stack Software Developer_ - [LinkedIn](https://www.linkedin.com/in/naam-pondpat-638153150/)