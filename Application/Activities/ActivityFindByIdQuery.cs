using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class ActivityFindByIdQuery
    {
        /// <summary>
        /// this query needs a object with Id and recievies a Activity Object
        /// </summary>
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly Context _context;

            public Handler(Context context)
            {
                _context = context;

            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);

                return activity;
            }
        }
    }
}