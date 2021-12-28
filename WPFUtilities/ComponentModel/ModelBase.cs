using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    public class ModelBase :
        ModelDataValidation,
        IModelBase,
        INotifyPropertyChanged
    {
        public bool IsDataValidationEnabled = true;

        bool _hasChanged = false;
        public bool HasChanged
        {
            get => _hasChanged;

            set
            {
                _hasChanged = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ModelBase()
        {
            ErrorsChanged += ModelBase_ErrorsChanged;
        }

        private void ModelBase_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(IsValid));
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!HasChanged) HasChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (IsDataValidationEnabled && propertyName != nameof(IsValid))
            {
                Validate(propertyName);
            }
        }
    }
}

