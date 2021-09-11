using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStackTask.Models
{
    public class DateOfBirthAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return DateTime.Now.Year - ((DateTime)value).Year > 18; 
        }
    }
}
