using System;
using System.ComponentModel.DataAnnotations;

namespace WPFUtilities.ComponentModel.ValidationAttributes
{
    public class OfTypeAttribute : ValidationAttribute
    {
        readonly Type _expectedType;

        public OfTypeAttribute(Type expectedType)
            => _expectedType = expectedType;

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            return (value != null && value.GetType().IsInstanceOfType(_expectedType)) ?
                ValidationResult.Success :
                new ValidationResult("value must be of type: " + _expectedType.FullName);
        }
    }
}
