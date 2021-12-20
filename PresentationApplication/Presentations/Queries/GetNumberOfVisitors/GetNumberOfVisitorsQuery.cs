using MediatR;
using PresentationApplication.Presentations.Queries.GetPresentationInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Queries.GetNumberOfVisitors
{
    public class GetNumberOfVisitorsQuery : IRequest<GetNumberOfVisitorsVm>
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
    }
}
