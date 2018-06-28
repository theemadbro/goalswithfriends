using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goalswithfriends.Models
{
    public class Members
    {
        [Key]
        public int id { get; set; }


        [ForeignKey("users")]
        public int memberid { get; set; }
        public Users member { get; set; }


        [ForeignKey("groups")]
        public int groupid { get; set; }
        public Groups group { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}