using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekatWP_bar.Model
{
    public class AttendingEvent
    {
        [Key]
        public int ID { get; set; }

        public User Attendee { get; set; }
        public Event Event { get; set; }

    }
}
