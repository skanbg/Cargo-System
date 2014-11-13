namespace CargoSystem.Data.Migrations
{
    using CargoSystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Carriers.Any() || context.Speditors.Any())
            {
                return;
            }

            var countriesToGenerate = 10;
            this.GenerateCountries(context, countriesToGenerate);

            var speditorsToGenerate = 10;
            this.GenerateSpeditors(context, speditorsToGenerate);

            var packagesToGenerate = 10;
            this.GeneratePackages(context, packagesToGenerate);

            var carriersToGenerate = 10;
            this.GenerateCarriers(context, carriersToGenerate);

            var vehiclesToGenerate = 10;
            this.GenerateVehicles(context, vehiclesToGenerate);

            var routesToGenerate = 10;
            this.GenerateRoutes(context, routesToGenerate);

            var offersToGenerate = 10;
            this.GenerateOffers(context, offersToGenerate);
        }

        private void GenerateRoutes(ApplicationDbContext context, int routesToGenerate)
        {
            var carriers = context.Carriers.OrderBy(c => Guid.NewGuid()).Take(routesToGenerate).ToArray();
            var vehicles = context.Vehicles.OrderBy(c => Guid.NewGuid()).Take(routesToGenerate).ToArray();

            for (int i = 0; i < routesToGenerate; i++)
            {
                var randomStartDate = this.RandomDay(DateTime.Now);
                var randomEndDate = this.RandomDay(randomStartDate);
                var route = new DeclaredRoute()
                {
                    Carrier = carriers[i % carriers.Length],
                    Vehicle = vehicles[i % vehicles.Length],
                    TransportStartDate = randomStartDate,
                    TransportEndDate = randomEndDate,
                    StartPoint = new Address() { Apartment = "Route start point address " + i },
                    EndPoint = new Address() { Apartment = "Route end point address " + i }
                };

                context.Routes.AddOrUpdate(route);
            }

            context.SaveChanges();
        }

        private DateTime RandomDay(DateTime startDate)
        {
            const int MAXDAYSTOADD = 100;
            Random gen = new Random();

            return startDate.AddDays(gen.Next(MAXDAYSTOADD));
        }

        private void GenerateOffers(ApplicationDbContext context, int offersToGenerate)
        {
            var speditors = context.Speditors.OrderBy(c => Guid.NewGuid()).Take(offersToGenerate).ToArray();
            var packages = context.Packages.OrderBy(c => Guid.NewGuid()).Take(offersToGenerate).ToArray();
            var routes = context.Routes.OrderBy(c => Guid.NewGuid()).Take(offersToGenerate).ToArray();

            for (int i = 0; i < offersToGenerate; i++)
            {
                var offer = new Offer()
                {
                    Route = routes[i % routes.Length],
                    Package = packages[i % packages.Length],
                    Speditor = speditors[i % speditors.Length],
                    Price = i,
                    OfferStatus = OfferStatus.Pending
                };

                context.Offers.AddOrUpdate(offer);
            }

            context.SaveChanges();
        }

        private void GeneratePackages(ApplicationDbContext context, int packagesToGenerate)
        {
            var speditors = context.Speditors.OrderBy(c => Guid.NewGuid()).Take(packagesToGenerate).ToArray();
            var countries = context.Countries.OrderBy(c => Guid.NewGuid()).Take(packagesToGenerate).ToArray();

            for (int i = 0; i < packagesToGenerate; i++)
            {
                var package = new Package()
                {
                    Speditor = speditors[i % speditors.Length],
                    SenderAddress = new Address()
                    {
                        Apartment = "Apartment " + i,
                        Country = countries[i % countries.Length]
                    },
                    Description = "Description of Package " + i,
                    Name = "Package " + i,
                    ReceiverAddress = new Address()
                    {
                        Apartment = "Apartment " + i,
                        Country = countries[i % countries.Length]
                    },
                    PackageState = PackageState.Shipping
                };

                context.Packages.AddOrUpdate(package);
            }

            context.SaveChanges();
        }

        private void GenerateVehicles(ApplicationDbContext context, int vehiclesToGenerate)
        {
            var carriers = context.Carriers.OrderBy(c => Guid.NewGuid()).Take(vehiclesToGenerate).ToArray();

            for (int i = 0; i < vehiclesToGenerate; i++)
            {
                var vehicle = new Vehicle()
                {
                    Dimensions = new TrailerSize() { Height = i, Width = i, Volume = i * i },
                    Owner = carriers[i % carriers.Length]
                };

                context.Vehicles.AddOrUpdate(vehicle);
            }

            context.SaveChanges();
        }

        private void GenerateCarriers(ApplicationDbContext context, int carriersToGenerate)
        {
            var password = GeneratePasswordHash("123");
            for (int i = 0; i < carriersToGenerate; i++)
            {
                var carrier = new Carrier()
                {
                    Name = "Carrier " + i.ToString(),
                    PasswordHash = password,
                    UserName = "carrier" + i + "@abv.bg",
                    Email = "carrier" + i + "@abv.bg",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                context.Carriers.AddOrUpdate(carrier);
            }

            context.SaveChanges();
        }

        private void GenerateSpeditors(ApplicationDbContext context, int speditorsToGenerate)
        {
            var password = GeneratePasswordHash("123");
            for (int i = 0; i < speditorsToGenerate; i++)
            {
                var speditor = new Speditor()
                {
                    Name = "Speditor " + i.ToString(),
                    PasswordHash = password,
                    UserName = "speditor" + i + "@abv.bg",
                    Email = "speditor" + i + "@abv.bg",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                context.Speditors.AddOrUpdate(speditor);
            }

            context.SaveChanges();
        }

        private string GeneratePasswordHash(string unhashedPassword)
        {
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword(unhashedPassword);
            return password;
        }

        private void GenerateCountries(ApplicationDbContext context, int countriesToGenerate)
        {
            string[] countryNames = new string[]
            {
	        "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla",
	        "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria",
	        "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin",
	        "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Bouvet Island",
	        "Brazil", "British Indian Ocean Territory", "Brunei Darussalam", "Bulgaria"
            };

            for (int i = 0; i < countriesToGenerate; i++)
            {
                var country = new Country()
                {
                    PhoneCode = "+00" + i,
                    Name = countryNames[i % countryNames.Length]
                };

                context.Countries.AddOrUpdate(country);
            }

            context.SaveChanges();
        }
    }
}
