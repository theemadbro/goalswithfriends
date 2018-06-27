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
    public class UsernameUniqueAttribute : ValidationAttribute
    {
        public UsernameUniqueAttribute()
        {}
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
            var _context = (goalswithfriendsContext) ValidationContext.GetService(typeof(goalswithfriendsContext));
            var checkUsername = _context.users.SingleOrDefault(login => login.username == (string)value);
            if (checkUsername == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Username already in use!");
            }
        }
    }
    public class BirthdayCheckAttribute : ValidationAttribute
    {
        public BirthdayCheckAttribute()
        {}
        protected override ValidationResult IsValid(object value, ValidationContext ValidationContext)
        {
           DateTime current = DateTime.Now.AddYears(-13);
           DateTime inp = (DateTime)value;
            if (current < inp)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Must be as least 13 years old to use Goals With Friends!");
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
        [UsernameUnique]
        [RegularExpression(@"(?!.*[\.\-_]{2,})^[a-zA-Z0-9\.\-_]{3,24}$", ErrorMessage="Usernames may only contain alphanumeric and the '-', '.' and '_' characters, non-repeating.")]
        public string username { get; set; }


        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage="Passwords must match!")]
        [NotMapped]
        public string passcheck { get; set; }


        public string bio { get; set; }


        public bool privacy { get; set; }


        [Required(ErrorMessage="Birthday is required!")]
        [BirthdayCheck]
        [DataType(DataType.Date)]
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
