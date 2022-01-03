using System;
using System.ComponentModel.DataAnnotations;

namespace WPFUtilities.ComponentModel.ValidationAttributes
{
    /// <summary>
    /// validates attribute type
    /// </summary>
    public class OfTypeAttribute : ValidationAttribute
    {
        readonly Type _expectedType;

        /// <summary>
        /// build a new instance
        /// </summary>
        /// <param name="expectedType">expected type</param>
        public OfTypeAttribute(Type expectedType)
            => _expectedType = expectedType;

        /// <summary>
        /// check attribute has expected type
        /// </summary>
        /// <param name="value">attribute value</param>
        /// <param name="validationContext">validation context</param>
        /// <returns>validation result</returns>
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
