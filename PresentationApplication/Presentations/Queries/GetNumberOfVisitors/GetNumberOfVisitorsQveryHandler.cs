using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;
using PresentationApplication.Interfaces;

using System.Threading;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Queries.GetNumberOfVisitors
{
    public class GetNumberOfVisitorsQveryHandler
    : IRequestHandler<GetNumberOfVisitorsQuery, GetNumberOfVisitorsVm>
    {
        private readonly IPresentationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNumberOfVisitorsQveryHandler(IPresentationDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<GetNumberOfVisitorsVm> Handle(GetNumberOfVisitorsQuery request,
            CancellationToken cansellationToken)
        {
            var entity = await _dbContext.Presentaions
                .FirstOrDefaultAsync(presentation =>
                presentation.EventId == request.EventId, cansellationToken);
            if (entity == null || entity.EventId != request.EventId)
            {
                throw new NotFoundException(nameof(Presentations), request.EventId);
            }
            
            return _mapper.Map<GetNumberOfVisitorsVm>(entity);
        }
    }
}
