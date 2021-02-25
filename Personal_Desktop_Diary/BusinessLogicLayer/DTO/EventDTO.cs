using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

        public UserDTO User { get; set; }
    }
}
