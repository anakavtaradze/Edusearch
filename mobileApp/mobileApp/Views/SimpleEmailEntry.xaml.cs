﻿using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace mobileApp.Views
{
    /// <summary>
    /// View used to show the email entry with validation status.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleEmailEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleEmailEntry" /> class.
        /// </summary>
        public SimpleEmailEntry()
        {
            this.InitializeComponent();
        }

        public string Value
        {
            get { return EmailEntry.Text; }
            set { EmailEntry.Text = value; }
        }
    }
}