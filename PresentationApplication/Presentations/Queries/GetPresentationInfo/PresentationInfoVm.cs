using AutoMapper;
using PresentationApplication.Common.Mappings;
using PresentationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Presentations.Queries.GetPresentationInfo
{
    public class PresentationInfoVm : IMapWith<Presentation>
    {
        //public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; } 
        public string EventDescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Presentation, PresentationInfoVm>()
                .ForMember(presentationVm => presentationVm.EventName,
                opt => opt.MapFrom(presentation => presentation.EventName))
              .ForMember(presentationVm => presentationVm.DateAndTime,
                opt => opt.MapFrom(presentation => presentation.DateAndTime))
                  .ForMember(presentationVm => presentationVm.EventDescription,
                opt => opt.MapFrom(presentation => presentation.EventDescription))
                    .ForMember(presentationVm => presentationVm.EventId,
                opt => opt.MapFrom(presentation => presentation.EventId));

        }
    }
}
