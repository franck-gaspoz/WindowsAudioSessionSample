using System.ComponentModel;

namespace WPFUtilities.ComponentModel
{
    public class ModelToObjectMediator
    {
        IModelBase _source;
        object _target;

        public void InitializeMediate(IModelBase source, object target)
        {
            ClearMediate();
            _source = source;
            _target = target;
            _source.PropertyChanged += ModelBase_PropertyChanged;
        }

        public void ClearMediate()
        {
            if (_source != null)
                _source.PropertyChanged -= ModelBase_PropertyChanged;
            _source = null;
            _target = null;
        }

        private void ModelBase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var sourceProperty = _source.GetType().GetProperty(e.PropertyName);
            var targetProperty = _target.GetType().GetProperty(e.PropertyName);

            if (sourceProperty != null
                && targetProperty != null
                && sourceProperty.PropertyType == targetProperty.PropertyType)
            {
                targetProperty.SetValue(
                    _target,
                    sourceProperty.GetValue(_source)
                    );
            }
        }
    }
}
