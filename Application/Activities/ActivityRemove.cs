using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ActivityRemove
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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

                _context.Activities.Remove(activity);

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
