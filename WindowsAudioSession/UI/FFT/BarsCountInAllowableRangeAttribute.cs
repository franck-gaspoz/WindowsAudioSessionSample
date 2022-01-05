using System;
using System.ComponentModel.DataAnnotations;

namespace WindowsAudioSession.UI.FFT
{
    /// <summary>
    /// validates that bars count is contained in the allowable range
    /// </summary>
    public class BarsCountInAllowableRangeAttribute : ValidationAttribute
    {
        /// <inheritdoc/>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(validationContext.ObjectInstance is FFTViewModel))
                return new ValidationResult($"can only by used in a model of type {typeof(FFTViewModel)}");

            if (App.WASMainViewModel == null)
                return ValidationResult.Success;

            var maxAllowed = Math.Min(4096, App.WASMainViewModel.FFTResolution / 2);

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
