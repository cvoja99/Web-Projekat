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

        public Club Klub{ get; set; }

        [Column("Ime Eventa")]
        [MaxLength(255)]
        public string Ime { get; set; }
        [Column("Kategorija")]
        [MaxLength(255)]
        public string Kategorija { get; set; }
        [JsonIgnore]
        public List<Vote> Glasovi { get; set; }
        public User Izvodjac { get; set; }

        [NotMapped]
        public float rating { get; set; }
    }
}
