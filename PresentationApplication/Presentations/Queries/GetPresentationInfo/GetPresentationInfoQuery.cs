using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Queries.GetPresentationInfo
{
    public class GetPresentationInfoQuery : IRequest<PresentationInfoVm>
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
    }
}
