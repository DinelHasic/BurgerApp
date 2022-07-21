using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Contracts.ViewModels.Utils
{
    internal class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            /*   DateTime.TryParse(value.ToString(), out DateTime date);

               if(date < DateTime.Now)
               {
                   return new ValidationResult("You can not set date to be less than the current date");
               }

               return ValidationResult.Success;*/

            return new ValidationResult("You can not set date to be less than the current date");

        }
    }
}
