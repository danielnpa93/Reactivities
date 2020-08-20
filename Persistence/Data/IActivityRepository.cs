using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetActivities();

        Task<Activity> GetActivityById(Guid id);
    }
}
