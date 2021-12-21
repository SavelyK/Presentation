using System;


namespace PresentationDomain
{
    public class Presentation
    {
        public Guid EventCreatorId { get; set; }
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public DateTime DateAndTime { get; set; }
        public string EventDescription { get; set; }
        public string Status { get; set; }
        public int CountVisiters { get; set; }

       
   
    }
}
