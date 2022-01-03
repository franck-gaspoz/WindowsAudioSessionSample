using System.ComponentModel;

namespace WPFUtilities.ComponentModel
{
    /// <summary>
    /// a mediator that transfer a model property value to an object property value
    /// </summary>
    public class ModelToObjectMediator
    {
        /// <summary>
        /// meditor source
        /// </summary>
        IModelBase _source;

        /// <summary>
        /// meditaor target
        /// </summary>
        object _target;

        /// <summary>
        /// build a model to object mediator for a source model and a target object, binds the mediator to the source
        /// </summary>
        /// <param name="source">mediator source</param>
        /// <param name="target">mediator target</param>
        public void InitializeMediate(IModelBase source, object target)
        {
            ClearMediate();
            _source = source;
            _target = target;
            _source.PropertyChanged += ModelBase_PropertyChanged;
        }

        /// <summary>
        /// clear the mediator bindings
        /// </summary>
        public void ClearMediate()
        {
            if (_source != null)
                _source.PropertyChanged -= ModelBase_PropertyChanged;
            _source = null;
            _target = null;
        }

        /// <summary>
        /// mediator source property changed event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
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
