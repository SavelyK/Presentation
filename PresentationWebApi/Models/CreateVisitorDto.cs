using AutoMapper;
using PresentationApplication.Common.Mappings;
using PresentationApplication.Presentations.Commands.CreateVisitor;
using System;


namespace PresentationWebApi.Models
{
    public class CreateVisitorDto : IMapWith<CreateVisitorCommand>
    {
      
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid EventId { get; set; }
        

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateVisitorDto, CreateVisitorCommand>()
                
                .ForMember(visitorCommand => visitorCommand.Name,
                opt => opt.MapFrom(visitorDto => visitorDto.Name))
                .ForMember(visitorCommand => visitorCommand.Surname,
                opt => opt.MapFrom(visitorDto => visitorDto.Surname))
                .ForMember(visitorCommand => visitorCommand.Patronymic,
                opt => opt.MapFrom(visitorDto => visitorDto.Patronymic))
                .ForMember(visitorCommand => visitorCommand.DateOfBirth,
                opt => opt.MapFrom(visitorDto => visitorDto.DateOfBirth))
                .ForMember(visitorCommand => visitorCommand.Gender,
                opt => opt.MapFrom(visitorDto => visitorDto.Gender))
                .ForMember(visitorCommand => visitorCommand.PhoneNumber,
                opt => opt.MapFrom(visitorDto => visitorDto.PhoneNumber))
                .ForMember(visitorCommand => visitorCommand.Email,
                opt => opt.MapFrom(visitorDto => visitorDto.Email));
    }
    }
}
