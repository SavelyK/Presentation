using PresentationApplication.Common.Mappings;
using PresentationApplication.Presentations.Commands.UpdatePresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationWebApi.Models
{
    public class UpdatePresentationDto : IMapWith<UpdatePresentationCommand>
    {
     
        public Guid EventId { get; set; }
        
        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<UpdatePresentationDto, UpdatePresentationCommand>()
                .ForMember(presentationCommand => presentationCommand.EventId,
                opt => opt.MapFrom(presentationDto => presentationDto.EventId));
        }
    }
}
