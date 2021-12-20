using System;
using MediatR;

namespace PresentationApplication.Presentations.Commands.CreatePresentation
{
    public class CreatePresentationCommand : IRequest<Guid>
    {
        
        public Guid EventCreatorId { get; set; }
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string EventDescription { get; set; }      
    }
}
