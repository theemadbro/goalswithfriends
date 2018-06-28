using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace goalswithfriends.Models
{
    
   
    public class CurrentUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
    }
}
