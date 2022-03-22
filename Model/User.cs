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
    [Table("User")]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Column("Ime")]
        [MaxLength(255)]
        public string Ime { get; set; }

        [Column("Prezime")]
        [MaxLength(255)]
        public string Prezime { get; set; }

        [Column("Email")]
        [MaxLength(255)]
        public string Email { get; set; }
        [JsonIgnore]
        public List<Vote> Vote { get; set; }

        [JsonIgnore]
        public List<Vote> VotedList { get; set; }
    }
}

