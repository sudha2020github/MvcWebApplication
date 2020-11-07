namespace MvcWebApplication.Migrations
{
    using MvcWebApplication.Models;
    using MvcWebApplication.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcWebApplication.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcWebApplication.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var carTypes = new List<CarType>
            {
            new CarType{TypeName="Convertibles"},
            new CarType{TypeName="Coupes"},
            new CarType{TypeName="Crossovers"},
            new CarType{TypeName="Electric Cars"},
            new CarType{TypeName="Hybrids"},
            new CarType{TypeName="Luxury Cars"},
            new CarType{TypeName="Sedans"},
            new CarType{TypeName="SUVs"},
            new CarType{TypeName="Sports Cars"},
            new CarType{TypeName="Minivans"}
           };
            carTypes.ForEach(s => context.CarType.Add(s));
            context.SaveChanges();

            var cars = new List<Car>
            {
            new Car{Make="Acura",Color="Metallic Blue",Year=2018,OwnerLastName="Santis",ImageFile="~/Content/Images/Acura.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=1},
            new Car{Make="Audi",Color="Azure Blue",Year=2019,OwnerLastName="Grace",ImageFile="~/Content/Images/Audi.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=9},
            new Car{Make="BMW",Color="Light Brown",Year=2018,OwnerLastName="George",ImageFile="~/Content/Images/BMW.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=6},
            new Car{Make="Toyota",Color="Metallic Red",Year=2015,OwnerLastName="David",ImageFile="~/Content/Images/Toyota.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=9},
            new Car{Make="Kia",Color="Gold",Year=2019,OwnerLastName="Yan",ImageFile="~/Content/Images/Kia.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=4},
            new Car{Make="Buick",Color="Silver",Year=2011,OwnerLastName="Mary",ImageFile="~/Content/Images/Buick.jpg",RecordCreationDate=DateTime.Now.Date, CarTypeID=1},
            new Car{Make="Cadillac",Color="Metallic Red",Year=2018,OwnerLastName="Laura",ImageFile="~/Content/Images/Cadillac.jpeg",RecordCreationDate=DateTime.Now.Date,CarTypeID=3},
            new Car{Make="Chevrolet",Color="Gold",Year=2019,OwnerLastName="Peggy",ImageFile="~/Content/Images/Chevy.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=10},
            new Car{Make="GMC",Color="Silver",Year=2018,OwnerLastName="Robert",ImageFile="~/Content/Images/Gmc.jpg",RecordCreationDate=DateTime.Now.Date,CarTypeID=2},
            };

            cars.ForEach(s => context.Car.Add(s));
            context.SaveChanges();
           
        }
    }
}
