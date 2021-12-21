using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;
using PresentationApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.DeleteVisiterCommand
{
    public class DeleteVisiterCommandHandler
    : IRequestHandler<DeleteVisiterCommand>
    {
        private readonly IPresentationDbContext _dbContext;
        public DeleteVisiterCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteVisiterCommand request,
            CancellationToken cansellationToken)
        {
            var entity = await _dbContext.Visitors
                .FindAsync(new object[] { request.VisitorId }, cansellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Presentations), request.EventId);
            }
            var entitys = await _dbContext.Presentaions.FirstOrDefaultAsync(precentation =>
          precentation.EventId == request.EventId, cansellationToken);
            entitys.CountVisiters--;

            _dbContext.Visitors.Remove(entity);
                await _dbContext.SaveChangesAsync(cansellationToken);
            

            return Unit.Value;
        }

    }
}
