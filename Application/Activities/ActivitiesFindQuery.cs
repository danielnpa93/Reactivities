using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class ActivitiesFindQuery
    {
        /// <summary>
        /// Query return values, in this case i pass a empty object and i recieve Activity object from database
        /// </summary>
        public class Query : IRequest<IEnumerable<Activity>> { }

        public class Handler : IRequestHandler<Query, IEnumerable<Activity>>
        {
            private readonly Context _context;

            public Handler(Context context)
            {
                _context = context;

            }
            public async Task<IEnumerable<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();

                return activities;

            }
        }
    }
}