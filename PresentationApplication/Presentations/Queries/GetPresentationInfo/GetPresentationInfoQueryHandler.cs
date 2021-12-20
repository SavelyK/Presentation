using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PresentationApplication.Common.Exceptions;
using PresentationApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Queries.GetPresentationInfo
{
    public class GetPresentationInfoQueryHandler
         : IRequestHandler<GetPresentationInfoQuery, PresentationInfoVm>
    {
        private readonly IPresentationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPresentationInfoQueryHandler(IPresentationDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<PresentationInfoVm> Handle(GetPresentationInfoQuery request,
            CancellationToken cansellationToken)
        {
            var entity = await _dbContext.Presentaions
                .FirstOrDefaultAsync(presentation =>
                presentation.EventId == request.EventId, cansellationToken);
            if (entity == null || entity.EventId != request.EventId)
            {
                throw new NotFoundException(nameof(Presentations), request.EventId);
            }
            return _mapper.Map<PresentationInfoVm>(entity);
        }
    }
}
