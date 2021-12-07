using System.Collections;
using System.Runtime.CompilerServices;

namespace WPFUtilities.ComponentModel
{
    public interface IModelDataValidation
    {
        bool IsValid { get; }

        bool HasErrors { get; }

        void Validate([CallerMemberName] string propertyName = null);

        void Validate();

        IEnumerable GetErrors(string propertyName);
    }
}
