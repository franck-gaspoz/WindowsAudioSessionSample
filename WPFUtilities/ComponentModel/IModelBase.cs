using System.ComponentModel;

namespace WPFUtilities.ComponentModel
{
    /// <summary>
    /// model base interface
    /// </summary>
    public interface IModelBase
    {
        /// <summary>
        /// enable/disable data validation
        /// </summary>
        bool IsDataValidationEnabled { get; set; }

        /// <summary>
        /// property changed event
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// indicates if any data has changed in the model
        /// </summary>
        bool HasModelChanged { get; }

        /// <summary>
        /// reset model state
        /// </summary>
        void ResetModelState();
    }
}
