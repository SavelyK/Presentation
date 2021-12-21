using AutoMapper;
using PresentationApplication.Common.Mappings;
using PresentationApplication.Presentations.Commands.ClosingPresentation;
using System;


namespace PresentationWebApi.Models
{
    public class ClosingPresentationDto : IMapWith<ClosingPresentationCommand>
    {
        public Guid EventId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ClosingPresentationDto, ClosingPresentationCommand>()
                .ForMember(presentationCommand => presentationCommand.EventId,
                opt => opt.MapFrom(presentationDto => presentationDto.EventId));

        }
    }
}
