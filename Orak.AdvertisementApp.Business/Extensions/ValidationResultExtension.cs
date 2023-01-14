using FluentValidation.Results;
using Orak.AdvertisementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.Business.Extensions
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
          
            List<CustomValidationError> errors = new();
            foreach (var validError in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = validError.ErrorMessage,
                    PropertyName = validError.PropertyName
                });
            }
            return errors;  
        }
    }
}
