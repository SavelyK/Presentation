using System;
using System.Collections.Generic;
using MediatR;
using PresentationDomain;

namespace PresentationApplication.Presentations.Commands.DeleteCommand
{
    public class DeletePresentationCommand : IRequest
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
  

    }
}
