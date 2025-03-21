﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace mobileApp.Behaviors
{
    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to  arbitrary conditions and events.
    /// </summary>
    /// <typeparam name="T">Behavior base parameter</typeparam>
    [Preserve(AllMembers = true)]
    public class BehaviorBase<T> : Behavior<T>
        where T : BindableObject
    {
        #region Properties
        public T AssociatedObject
        {
            get;
            private set;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Invoked when adding Entry to the view.
        /// </summary>
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            this.AssociatedObject = bindable;
            if (bindable?.BindingContext != null)
            {
                this.BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += this.OnBindingContextChanged;
        }

        /// <summary>
        /// Invoked when exit from the view.
        /// </summary>
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);

            if (bindable != null)
            {
                bindable.BindingContextChanged -= this.OnBindingContextChanged;
                this.AssociatedObject = null;
            }
        }

        /// <summary>
        /// Invoked when Entry binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.BindingContext = this.AssociatedObject.BindingContext;
        }

        /// <summary>
        /// Invoked when BindingContext is changed
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            this.OnBindingContextChanged();
        }

        #endregion
    }
}
