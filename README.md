# MvcWebApplication
This is a simple ASP.NET MVC application built using Visual Studio 2019 and MSSQLServer. This application implements basic authentication and registration. The users will need to register with the site by providing an email and password. The service validates the email and password for strength and stores in the database. Passwords are stored as a hash in the database and can be reset by the users. This application has a car inventory and has basic navigation between  Home, About, and Contact.  This application has searching, sorting, paging and validations.
Pre-Requisites:
Please create the database as per the connection string in the webconfig. Use the database scripts to create the database schemas.
Also Enable the Migrations and update the database in the target machine to avoid Model compatability errors.
