using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projekatWP_bar.Model
{

    [Table("Vote")]
    public class Vote
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User Voter { get; set; }
        [ForeignKey("EventID")]
        public int EventID { get; set; }
       
        public Event Event { get; set; }
        [Column("Rating")]
        public int Rating { get; set; }

    }
}
