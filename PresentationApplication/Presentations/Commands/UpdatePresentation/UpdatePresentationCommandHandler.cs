using PresentationDomain;
using PresentationApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;

namespace PresentationApplication.Presentations.Commands.UpdatePresentation
{
    public class UpdatePresentationCommandHandler
        : IRequestHandler<UpdatePresentationCommand>
    {
        private readonly IPresentationDbContext _dbContext;
        public UpdatePresentationCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdatePresentationCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Presentaions.FirstOrDefaultAsync(precentation => 
            precentation.EventId == request.EventId, cancellationToken);
            if(entity == null || entity.EventCreatorId != request.EventCreatorId)
            {
                throw new NotFoundException(nameof(Presentation), request.EventId);
            }
       
             entity.EventName = request.EventName;
             entity.DateAndTime = request.DateAndTime;
             entity.EventDescription = request.EventDescription;

             await _dbContext.SaveChangesAsync(cancellationToken);

             return Unit.Value; 
        }
    }
}
