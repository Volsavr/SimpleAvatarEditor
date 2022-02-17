using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Input;

namespace AvatarEditor.Triggers
{
    internal class TapActionTrigger : TriggerBase<UIElement>
    {
        #region Protected Members

        protected override void OnAttached()
        {
            base.OnAttached();

            if (base.AssociatedObject != null)
            {
                AttachHandlers();
            }
        }

        protected override void OnDetaching()
        {
            if (base.AssociatedObject != null)
            {
                DetachHandlers();
            }
            base.OnDetaching();
        }

        #endregion

        #region Private methods

        private void AttachHandlers()
        {
            base.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseDown;
        }

        private void DetachHandlers()
        {
            base.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseDown;
        }

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            base.InvokeActions(null);
        }

        #endregion
    }
}
