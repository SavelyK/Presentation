using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.DeleteVisiterCommand
{
    public class DeleteVisiterCommand : IRequest
    {
        public Guid VisitorId { get; set; }
        public Guid EventId { get; set; }
    }
}
