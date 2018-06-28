using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace goalswithfriends.Models
{
    
    public class Goals
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string goal { get; set; }


        public string desc { get; set; }


        public string status { get; set; }

        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }


        [ForeignKey("users")]
        public int usersid { get; set; }
        public Users user { get; set; }


        [ForeignKey("groups")]
        public int groupid { get; set; }
        public Groups group { get; set; }

        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }
}
