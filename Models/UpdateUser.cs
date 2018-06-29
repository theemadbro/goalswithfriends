using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace goalswithfriends.Models
{
    public class UpdateUser
    {


        [Required]
        [MinLength(2)]
        [RegularExpression("([a-zA-Z]+[,.]?[ ]?|[a-zA-Z]+['-]?)+$", ErrorMessage="Numbers shouldn't be in names!")]
        public string first_name { get; set; }


        [Required]
        [MinLength(2)]
        [RegularExpression("^([a-zA-Z]+[,.]?[ ]?|[a-zA-Z]+['-]?)+$", ErrorMessage="Numbers shouldn't be in names!")]
        public string last_name { get; set; }


        public bool privacy { get; set; }

    }
}
