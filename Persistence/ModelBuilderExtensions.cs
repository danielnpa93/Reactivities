using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence
{
    public static class ModelBuilderExtensions
    {

        public static void SeedActivity(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Activity>().HasData(
             new Activity { Category = "a", City = "London", Date = DateTime.Now.AddMonths(8), Description = "Description", Title = "Future Activity 8", Venue = "Cinema", Id = Guid.NewGuid() },
              new Activity { Category = "b", City = "London", Date = DateTime.Now.AddMonths(8), Description = "Description", Title = "Future Activity 8", Venue = "Cinema", Id = Guid.NewGuid() },
              new Activity { Category = "c", City = "London", Date = DateTime.Now.AddMonths(8), Description = "Description", Title = "Future Activity 8", Venue = "Cinema", Id = Guid.NewGuid() }
            );
            // }
        }
    }
}
