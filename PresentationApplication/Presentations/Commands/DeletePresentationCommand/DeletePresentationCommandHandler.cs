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
        public DeletePresentationCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeletePresentationCommand request, 
            CancellationToken cansellationToken)
        {
            var entity = await _dbContext.Presentaions
                .FindAsync(new object[] { request.EventId }, cansellationToken);
            if(entity == null )
            {
                throw new NotFoundException(nameof(Presentations), request.EventId);
            }
            else if (entity.CountVisiters == 0)
            {
                _dbContext.Presentaions.Remove(entity);
                await _dbContext.SaveChangesAsync(cansellationToken);
            }
            
                return Unit.Value;
        }
        
    }
}
