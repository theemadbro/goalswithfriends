using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace goalswithfriends.Models
{
    public class Groups
    {
        [Key]
        public int id { get; set; }


        [Required]
        public string name { get; set; }


        [ForeignKey("users")]
        public int ownerid { get; set; }
        public Users owner { get; set; }


        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }


        public string desc { get; set; }


        public List<Members> members { get; set; }
        public Groups()
        {
            members = new List<Members>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }
    }
}