using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projekatWP_bar.Model
{
    [Table("Klub")]
    public class Club
    {
        [Key]
        public int ID { get; set; }

        [Column("Ime")]
        [MaxLength(255)]
        public string Ime { get; set; }

        [Column("Adresa")]
        [MaxLength(255)]
        public string Adresa { get; set; }

        public List<Event> listaEventova { get; set; }
    }
}
