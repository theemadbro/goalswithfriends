using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace goalswithfriends.Models
{
    public class GoalsU : IValidatableObject
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string goal { get; set; }


        public string desc { get; set; }


        public string status { get; set; }


        [Required(ErrorMessage="Required")]
        [DataType(DataType.Date, ErrorMessage="Input required!")]
        public DateTime startDate { get; set; }


        [Required(ErrorMessage="Required")]
        [DataType(DataType.Date, ErrorMessage="Input required!")]
        public DateTime endDate { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (endDate < startDate)
            {
                yield return 
                    new ValidationResult(errorMessage: "Start Date can't be after End Date!",
                                        memberNames: new[] { "endDate" });
            }
        }


        [ForeignKey("users")]
        public int usersid { get; set; }
        public Users user { get; set; }

        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime created_at { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime updated_at { get; set; }

    }
}
