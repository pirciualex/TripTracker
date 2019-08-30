using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using TripTracker.API.Models;

namespace TripTracker.API.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TripContext>();
            context.Database.EnsureCreated();
            if (!context.Trips.Any())
            {
                context.AddRange(new List<Trip>()
                {
                    new Trip
                    {
                        Id = 1,
                        Name = "Arad Trip",
                        StartDateTime = new DateTime(2019, 06, 20),
                        EndDateTime = new DateTime(2019, 06, 23)
                    },
                    new Trip
                    {
                        Id = 2,
                        Name = "Nadas Camp",
                        StartDateTime = new DateTime(2019, 08, 13),
                        EndDateTime = new DateTime(2019, 08, 18)
                    },
                    new Trip
                    {
                        Id = 3,
                        Name = "BACStud2019",
                        StartDateTime = new DateTime(2019, 10, 17),
                        EndDateTime = new DateTime(2019, 10, 19)
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
