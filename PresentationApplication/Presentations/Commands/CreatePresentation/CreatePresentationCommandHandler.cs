using System;
using PresentationDomain;
using System.Threading;
using PresentationApplication.Interfaces;
using System.Threading.Tasks;
using MediatR;

namespace PresentationApplication.Presentations.Commands.CreatePresentation
{
    public class CreatePresentationCommandHandler
        : IRequestHandler<CreatePresentationCommand, Guid>
    {
        private readonly IPresentationDbContext _dbContext;
        public CreatePresentationCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreatePresentationCommand request,
            CancellationToken cancellationToken)
        {
            var presentation = new Presentation
            {
                EventCreatorId = request.EventCreatorId,
                EventId = Guid.NewGuid(),
                EventName = request.EventName,
                DateAndTime = request.DateAndTime,
                EventDescription = request.EventDescription
            };
            await _dbContext.Presentaions.AddAsync(presentation, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return presentation.EventId;
        }
    }

}


