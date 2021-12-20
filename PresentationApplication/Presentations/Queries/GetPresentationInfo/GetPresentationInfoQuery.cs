using MediatR;
using System;


namespace PresentationApplication.Presentations.Queries.GetPresentationInfo
{
    public class GetPresentationInfoQuery : IRequest<PresentationInfoVm>
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
    }
}
