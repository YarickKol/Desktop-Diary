using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Profiles;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class EventService:IDisposable
    {
        private bool isDisposed = false;
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            mapper = AutomapperProfileConfiguration.Configure().CreateMapper();
        }
        public void AddEvent(EventDTO event1)
        {
            var transEvent = mapper.Map<EventDTO, Event>(event1);
            _unitOfWork.Events.CreateItem(transEvent);            
        }

        public IList<EventDTO> GetProducts(UserDTO user)
        {
            User user1 = _unitOfWork.Users.GetSingleItem(u => u.Id == user.Id);
             var products = mapper.Map<IEnumerable<Event>, IList<EventDTO>>(
                  _unitOfWork.Events.GetEventsByUser(user1));
             return products;
            
        }

        public void Dispose()
        {
            Dispose(true);            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                _unitOfWork.Dispose();
                isDisposed = true;
            }
        }
    }
}
