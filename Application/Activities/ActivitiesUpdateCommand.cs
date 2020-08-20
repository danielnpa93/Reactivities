using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ActivitiesUpdateCommand
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime? Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly Context _context;

            public Handler(Context context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {


                var activity = await _context.Activities.FindAsync(request.Id);

                if (activity == null)
                {
                    throw new Exception("Could not find activity");
                }

                activity.Category = request.Category ?? activity.Category;
                activity.City = request.City ?? activity.City;
                activity.Date = request.Date ?? activity.Date;
                activity.Description = request.Description ?? activity.Description;
                activity.Title = request.Title ?? activity.Title;
                activity.Venue = request.Venue ?? activity.Venue;

                var wasSaved = await _context.SaveChangesAsync() > 0;

                if (wasSaved)
                {
                    return Unit.Value;
                }

                throw new Exception("Problem Saving Changes");


            }


        }
    }
}
