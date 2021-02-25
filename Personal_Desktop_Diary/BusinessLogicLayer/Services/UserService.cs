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
    public class UserService:IDisposable
    {
        private bool isDisposed = false;
        private IUnitOfWork _unitOfWork;
        private IMapper mapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            mapper = AutomapperProfileConfiguration.Configure().CreateMapper();
        }

        public UserDTO LoginUser(string username, string password)
        {
            User user = _unitOfWork.Users.GetSingleItem(u => u.UserName == username &&
            u.Password == password);

            if (user != null)
            {
                return mapper.Map<User, UserDTO>(user);
            }

            return null;
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
