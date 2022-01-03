using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    /// <summary>
    /// validable model
    /// </summary>
    public class ValidableModel : INotifyDataErrorInfo, IValidableModel
    {
        /// <summary>
        /// property errors
        /// </summary>
        public readonly IDictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

        /// <summary>
        /// errors changed event
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        /// indicates if model is valid or not
        /// </summary>
        public bool IsValid => Errors.Count == 0;

        /// <summary>
        /// triggers a model validation for the property with given name
        /// </summary>
        /// <param name="propertyName">property name (optional, call member name if ommitted)</param>
        /// <returns>true if the property is valid or doesn't exists, false otherwize</returns>
        public bool Validate([CallerMemberName] string propertyName = null)
        {
            var property = GetType().GetProperty(propertyName);
            if (property == null)
                return true;

            var val = property.GetValue(this);

            if (Errors.ContainsKey(propertyName)) _ = Errors.Remove(propertyName);

            var context = new ValidationContext(this) { MemberName = propertyName };
            var results = new List<ValidationResult>();
            var hasErrors = false;

            if (!Validator.TryValidateProperty(val, context, results))
            {
                Errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
                hasErrors = true;
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

            return !hasErrors;
        }

        /// <summary>
        /// validates the model
        /// </summary>
        /// <returns>true if the model is valid, false otherwize</returns>
        public bool Validate()
        {
            foreach (var property in GetType().GetProperties())
            {
                if (property.GetCustomAttributes(true).Any(x => x is ValidationAttribute))
                    Validate(property.Name);
            }
            return HasErrors;
        }

        /// <summary>
        /// indicates if model has errors or not
        /// </summary>
        public bool HasErrors => Errors.Any();

        /// <summary>
        /// get errors of a property
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <returns>enumerable errors</returns>
        public IEnumerable GetErrors(string propertyName)
        {
            return Errors.ContainsKey(propertyName) ? Errors[propertyName] : null;
        }
    }
}
