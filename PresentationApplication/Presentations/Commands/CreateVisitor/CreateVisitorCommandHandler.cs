using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;
using PresentationApplication.Interfaces;
using PresentationDomain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.CreateVisitor
{
    public class CreateVisitorCommandHandler
   : IRequestHandler<CreateVisitorCommand, Guid>
    {
        private readonly IPresentationDbContext _dbContext;
        public CreateVisitorCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateVisitorCommand request,
            CancellationToken cancellationToken)
        {
            
            var visitor = new Visitor
            {
                VisitorId = Guid.NewGuid(),
                DateOfBirth = request.DateOfBirth,
                Name = request.Name,
                Email = request.Email,
                Gender = request.Gender,
                Patronymic = request.Patronymic,
                PhoneNumber = request.PhoneNumber,
                Surname = request.Surname,
                EventId = request.EventId
             };

            var entity = await _dbContext.Presentaions.FirstOrDefaultAsync(precentation =>
           precentation.EventId == request.EventId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Presentations), request.EventId);
            }
            entity.CountVisiters++;
             
            
            await _dbContext.Visitors.AddAsync(visitor, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return visitor.VisitorId;
        }
    }
}
