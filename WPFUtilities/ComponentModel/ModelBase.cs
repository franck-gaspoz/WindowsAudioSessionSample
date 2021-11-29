using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    public class ModelBase :
        INotifyPropertyChanged,
        INotifyDataErrorInfo
    {
        bool _isDirty = false;
        public bool IsDirty
        {
            get => _isDirty;

            set
            {
                _isDirty = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsChangesTrackingEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public string ErrorResume => HasErrors ? _errors.First().Value[0] : "";
        public bool HasErrors => _errors.Count > 0;

        protected void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (IsChangesTrackingEnabled && !IsDirty)
                IsDirty = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void SetErrors(List<string> propertyErrors, [CallerMemberName] string propertyName = "")
        {
            // Clear any errors that already exist for this property.
            _errors.Remove(propertyName);
            // Add the list collection for the specified property.
            _errors.Add(propertyName, propertyErrors);
            // Raise the error-notification event.
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearErrors([CallerMemberName] string propertyName = "")
        {
            // Remove the error list for this property.
            _errors.Remove(propertyName);
            // Raise the error-notification event.
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                // Provide all the error collections.
                return (_errors.Values);
            }
            else
            {
                // Provide the error collection for the requested property if it has errors
                if (_errors.ContainsKey(propertyName))
                {
                    return (_errors[propertyName]);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

