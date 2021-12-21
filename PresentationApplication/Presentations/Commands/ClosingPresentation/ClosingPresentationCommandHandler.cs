using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;
using PresentationApplication.Interfaces;
using PresentationDomain;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.ClosingPresentation
{
    public class ClosingPresentationCommandHandler
      : IRequestHandler<ClosingPresentationCommand>
    {
        private readonly IPresentationDbContext _dbContext;
        public ClosingPresentationCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(ClosingPresentationCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Presentaions.FirstOrDefaultAsync(precentation =>
            precentation.EventId == request.EventId, cancellationToken);
            if (entity == null || entity.EventCreatorId != request.EventCreatorId)
            {
                throw new NotFoundException(nameof(Presentation), request.EventId);
            }

            entity.Status = "Closed";
            entity.EventId = request.EventId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
