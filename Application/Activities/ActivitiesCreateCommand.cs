using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class ActivitiesCreateCommand
    {
        /// <summary>
        /// commands does not return values
        /// </summary>
        public class Command : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        /// <summary>
        /// require a command object decalred above, and dont return. Note: Unit is a empty object.
        /// </summary>
        public class Handler : IRequestHandler<Command>
        {
            private readonly Context _context;

            public Handler(Context context )
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Add(new Activity
                {
                    Category = request.Category,
                    City = request.City,
                    Date = request.Date,
                    Description = request.Description,
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Venue = request.Venue
                }); //can use mapper

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