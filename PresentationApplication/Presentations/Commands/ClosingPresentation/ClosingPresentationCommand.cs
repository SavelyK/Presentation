using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.ClosingPresentation
{
    public class ClosingPresentationCommand : IRequest
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
        public string Status { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime DateAndTime { get; set; }
    } 
}
