using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;
using PresentationApplication.Interfaces;
using PresentationApplication.Presentations.Commands.UpdatePresentation;
using PresentationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.UpdateVisiter
{
    public class UpdateVisitorCommandHandler
      : IRequestHandler<UpdateVisitorCommand>
    {
        private readonly IPresentationDbContext _dbContext;
        public UpdateVisitorCommandHandler(IPresentationDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateVisitorCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Visitors.FirstOrDefaultAsync(precentation =>
            precentation.VisitorId == request.VisitorId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Visitor), request.EventId);
            }

            entity.DateOfBirth = request.DateOfBirth;
            entity.Email = request.Email;
            entity.Gender = request.Gender;
            entity.Name = request.Name;
            entity.Patronymic = request.Patronymic;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Surname = request.Surname;
         

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
