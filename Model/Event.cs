using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projekatWP_bar.Model
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int ID { get; set; }

        [JsonIgnore]
        public Club Klub{ get; set; }

        [Column("Ime Eventa")]
        [MaxLength(255)]
        public string Ime { get; set; }
        [Column("Kategorija")]
        [MaxLength(255)]
        public string Kategorija { get; set; }
        public List<Vote> Glasovi { get; set; }
        public User Izvodjac { get; set; }
        public List<AttendingEvent> Gosti { get; set; }
    }
}
