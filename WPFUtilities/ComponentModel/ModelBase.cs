using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    /// <summary>
    /// base model with notifiable and validable data
    /// </summary>
    public class ModelBase :
        ValidableModel,
        IModelBase,
        INotifyPropertyChanged
    {
        /// <summary>
        /// enable/disable data validation
        /// </summary>
        public bool IsDataValidationEnabled { get; set; } = true;

        bool _hasModelChanged = false;
        /// <summary>
        /// indicates if any data has changed in the model
        /// </summary>
        public bool HasModelChanged
        {
            get => _hasModelChanged;

            set
            {
                _hasModelChanged = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// build a new model base
        /// </summary>
        public ModelBase()
        {
            ErrorsChanged += ModelBase_ErrorsChanged;
        }

        /// <summary>
        /// errors changed event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void ModelBase_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(IsValid));
        }

        /// <summary>
        /// notify a property has changed
        /// </summary>
        /// <param name="propertyName">property name (caller member name if omitted)</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!HasModelChanged) HasModelChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (IsDataValidationEnabled && propertyName != nameof(IsValid))
            {
                Validate(propertyName);
            }
        }

        /// <summary>
        /// reset model state
        /// </summary>
        public void ResetModelState() => HasModelChanged = false;
    }
}

