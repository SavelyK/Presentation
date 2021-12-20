using AutoMapper;
using PresentationApplication.Common.Mappings;
using PresentationApplication.Presentations.Commands.CreatePresentation;
using System;

namespace PresentationWebApi.Models
{
    public class CreatePresentationDto : IMapWith<CreatePresentationCommand>
    {
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string EventDescription { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePresentationDto, CreatePresentationCommand>()
                .ForMember(presentationCommand => presentationCommand.EventName,
                opt => opt.MapFrom(presentationDto => presentationDto.EventName))
                .ForMember(presentationCommand => presentationCommand.DateAndTime,
                opt => opt.MapFrom(presentationDto => presentationDto.DateAndTime))
                .ForMember(presentationCommand => presentationCommand.EventDescription,
                opt => opt.MapFrom(presentationDto => presentationDto.EventDescription));
        }
    }
}
