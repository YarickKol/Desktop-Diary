using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLibrary.Models;

namespace BusinessLogicLayer.Profiles
{
    public class EventProfile:Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
            
        }
    }
}
