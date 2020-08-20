using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class SqliteRepositorty : IActivityRepository
    {
        private readonly Context _context;

        public SqliteRepositorty(Context context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            var activities = await _context.Activities.ToListAsync();
            return activities;
        }

        public async Task<Activity> GetActivityById(Guid id)
        {
            var activity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == id);

            return activity;
        }
    }
}
