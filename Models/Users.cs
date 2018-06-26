using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace goalswithfriends.Models
{
    
    public class EmailUniqueAttribute : ValidationAttribute
    {
        public EmailUniqueAttribute()
        {}
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
            var _context = (goalswithfriendsContext) ValidationContext.GetService(typeof(goalswithfriendsContext));
            var checkEmail = _context.users.SingleOrDefault(login => login.email == (string)value);
            if (checkEmail == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Email already in use!");
            }
        }
    }
    public class Users
    {
        [Key]
        public int id { get; set; }


        [Required]
        [MinLength(2)]
        [RegularExpression("([a-zA-Z]+[,.]?[ ]?|[a-zA-Z]+['-]?)+$", ErrorMessage="Numbers shouldn't be in names!")]
        public string first_name { get; set; }


        [Required]
        [MinLength(2)]
        [RegularExpression("^([a-zA-Z]+[,.]?[ ]?|[a-zA-Z]+['-]?)+$", ErrorMessage="Numbers shouldn't be in names!")]
        public string last_name { get; set; }


        [Required]
        [EmailUnique]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }


        public string bio { get; set; }


        public DateTime birthday { get; set; }


        public List<Groups> groups { get; set; }


        public List<Goals> goals { get; set; }
        public Users()
        {
            goals = new List<Goals>();
            groups = new List<Groups>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }
}
