using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime EventStart { get; set; }

        public DateTime EventEnd { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
