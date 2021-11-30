using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    public class ModelBase :
        ModelDataValidation,
        INotifyPropertyChanged
    {
        public bool IsDataValidationEnabled = true;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!IsDirty) IsDirty = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (IsDataValidationEnabled)
            {
                Validate(propertyName);
            }
        }
    }
}

