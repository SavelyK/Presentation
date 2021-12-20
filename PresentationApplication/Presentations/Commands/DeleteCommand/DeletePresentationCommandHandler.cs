using MediatR;
using PresentationApplication.Interfaces;
using PresentationApplication.Common.Exceptions;
using System.Threading;
using System.Threading.Tasks;


namespace PresentationApplication.Presentations.Commands.DeleteCommand
{
    
    public class DeletePresentationCommandHandler
        : IRequestHandler<DeletePresentationCommand>
    {
        private readonly IPresentationDbContext _dbContext;
        public async Task<Unit> Handle(DeletePresentationCommand request, 
            CancellationToken cansellationToken)
        {
            var entity = await _dbContext.Presentaions
                .FindAsync(new object[] { request.EventId }, cansellationToken);
            if(entity == null || entity.EventCreatorId != request.EventCreatorId)
            {
                throw new NotFoundException(nameof(Presentations), request.EventId);
            }
    
            _dbContext.Presentaions.Remove(entity);
            await _dbContext.SaveChangesAsync(cansellationToken);
            return Unit.Value;
        }
        
    }
}
