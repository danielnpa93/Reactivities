using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class MockActivityRepository : IActivityRepository
    {
        public Task<IEnumerable<Activity>> GetActivities()
        {
            var activityList = new List<Activity>() {
             new Activity { Category="1",City="New York",Date=new DateTime(),Description="none",Id=new Guid(),Title="title",Venue="venue"},
             new Activity { Category="1",City="New York",Date=new DateTime(),Description="none",Id=new Guid(),Title="title",Venue="venue"},
             new Activity { Category="1",City="New York",Date=new DateTime(),Description="none",Id=new Guid(),Title="title",Venue="venue"},
             new Activity { Category="1",City="New York",Date=new DateTime(),Description="none",Id=new Guid(),Title="title",Venue="venue"},
            };

            var action = Task<IEnumerable<Activity>>.Factory.StartNew(() => activityList);

            return action;
        }

        public Task<Activity> GetActivityById(Guid id)
        {

            return Task.Factory.StartNew(() => new Activity
            {
                Category = "1",
                City = "New York",
                Date = new DateTime(),
                Description = "none",
                Id = new Guid(),
                Title = "title",
                Venue = "venue"
            });
        }
    }
}
