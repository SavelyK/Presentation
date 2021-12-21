using AutoMapper;
using PresentationApplication.Common.Mappings;
using PresentationDomain;
using System;


namespace PresentationApplication.Presentations.Queries.GetNumberOfVisitors
{
    public class GetNumberOfVisitorsVm : IMapWith<Presentation>
    {
        
        public Guid EventId { get; set; }
        public int Count { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Presentation, GetNumberOfVisitorsVm>()

              .ForMember(presentationVm => presentationVm.EventId,
                opt => opt.MapFrom(presentation => presentation.EventId))
            .ForMember(presentationVm => presentationVm.Count,
                opt => opt.MapFrom(presentation => presentation.CountVisiters));



        }
    }
}
