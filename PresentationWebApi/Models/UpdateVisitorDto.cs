using PresentationApplication.Common.Mappings;
using PresentationApplication.Presentations.Commands.UpdateVisiter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationWebApi.Models 
{
    public class UpdateVisitorDto : IMapWith<UpdateVisitorCommand>
    {
        public Guid VisitorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<UpdateVisitorDto, UpdateVisitorCommand>()
                 .ForMember(presentationCommand => presentationCommand.VisitorId,
                opt => opt.MapFrom(presentationDto => presentationDto.VisitorId))
                  .ForMember(presentationCommand => presentationCommand.Name,
                opt => opt.MapFrom(presentationDto => presentationDto.Name))
                   .ForMember(presentationCommand => presentationCommand.Surname,
                opt => opt.MapFrom(presentationDto => presentationDto.Surname))
                   .ForMember(presentationCommand => presentationCommand.Patronymic,
                opt => opt.MapFrom(presentationDto => presentationDto.Patronymic))
                  .ForMember(presentationCommand => presentationCommand.DateOfBirth,
                opt => opt.MapFrom(presentationDto => presentationDto.DateOfBirth))
                   .ForMember(presentationCommand => presentationCommand.Gender,
                opt => opt.MapFrom(presentationDto => presentationDto.Gender))
                   .ForMember(presentationCommand => presentationCommand.PhoneNumber,
                opt => opt.MapFrom(presentationDto => presentationDto.PhoneNumber))
                  .ForMember(presentationCommand => presentationCommand.Email,
                opt => opt.MapFrom(presentationDto => presentationDto.Email));
        }
    }
}
