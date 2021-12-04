using System;
using System.ComponentModel.DataAnnotations;

namespace WindowsAudioSession.UI.FFT
{
    public class BarsCountValidationAttribute : ValidationAttribute
    {
        public BarsCountValidationAttribute() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(validationContext!=null && validationContext.ObjectInstance is FFTControlViewModel))
                return new ValidationResult($"can only by used in a model of type {typeof(FFTControlViewModel)}");

            var maxAllowed = Math.Min(4096, App.WASOverviewWindowViewModel.FFTResolution / 2);

            return !(value is int intValue)
                ? new ValidationResult($"must be integer >= 1 and <= {maxAllowed}")
                : intValue < 1
                ? new ValidationResult("minium is 1")
                : intValue > maxAllowed
                ? new ValidationResult($"maximum is {maxAllowed}")
                : ValidationResult.Success;
        }
    }
}
