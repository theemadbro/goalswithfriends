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


        public string goal { get; set; }


        public string desc { get; set; }


        public string status { get; set; }


        public DateTime startDate { get; set; }


        public DateTime endDate { get; set; }


        public int usersid { get; set; }
        [ForeignKey("usersid")]
        public Users user { get; set; }


        public int groupid { get; set; }
        [ForeignKey("groupid")]
        public Groups group { get; set; }

        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }
}
