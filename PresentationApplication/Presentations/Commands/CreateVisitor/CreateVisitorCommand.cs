using MediatR;
using PresentationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Commands.CreateVisitor
{
    public class CreateVisitorCommand : IRequest<Guid>
    {

        public Guid VisitorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid EventId { get; set; }
        public List<Visitor> Visitors { get; set; }
    }
}
