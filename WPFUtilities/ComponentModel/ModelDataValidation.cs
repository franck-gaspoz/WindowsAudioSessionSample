using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    public class ModelDataValidation : INotifyDataErrorInfo
    {
        public readonly IDictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool IsValid => Errors.Count == 0;

        public void Validate([CallerMemberName] string propertyName = null)
        {
            var property = GetType().GetProperty(propertyName);
            if (property == null)
                return;

            var val = property.GetValue(this);

            if (Errors.ContainsKey(propertyName)) _ = Errors.Remove(propertyName);

            var context = new ValidationContext(this) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(val, context, results))
            {
                Errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        /// <summary>
        /// validates the model
        /// </summary>
        public void Validate()
        {

        }

        public bool HasErrors => Errors.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            return Errors.ContainsKey(propertyName) ? Errors[propertyName] : null;
        }
    }
}
