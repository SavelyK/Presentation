using System;
using MediatR;

namespace PresentationApplication.Presentations.Commands.UpdatePresentation
{
    public class UpdatePresentationCommand : IRequest
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string EventDescription { get; set; }

    }
}
