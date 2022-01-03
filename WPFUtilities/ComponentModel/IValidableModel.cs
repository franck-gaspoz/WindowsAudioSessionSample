using System.Collections;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    /// <summary>
    /// validable model interface
    /// </summary>
    public interface IValidableModel
    {
        /// <summary>
        /// indicates if model is valid or not
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// indicates if model has errors or not
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// validates a property of the model
        /// </summary>
        /// <returns>true if the property is valid or doesn't exists, false otherwize</returns>
        bool Validate([CallerMemberName] string propertyName = null);

        /// <summary>
        /// validate the model
        /// </summary>
        /// <returns>true if the model is valid, false otherwize</returns>
        bool Validate();

        /// <summary>
        /// get errors of a property
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <returns>enumerable errors</returns>
        IEnumerable GetErrors(string propertyName);
    }
}
