using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileApplication.Models;

namespace MobileApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        public DateTime MaxDate { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            MaxDate = DateTime.Today.AddYears(-18);

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        private void PhoneFocus(object sender, FocusEventArgs args)
        {
            if(!string.IsNullOrWhiteSpace(((Entry)args.VisualElement).Text))
                ((Entry)args.VisualElement).Text = "(";
        }

        private void PhoneTextChanged(object sender, TextChangedEventArgs args)
        {
            string val = args.NewTextValue;
            if (!string.IsNullOrEmpty(val))
            {
                // If the new value is longer than the old value, the user is
                if (args.OldTextValue != null && args.NewTextValue.Length < args.OldTextValue.Length)
                    return;

                if (val.Length == 0)
                {
                    ((Entry)sender).Text += "(";
                    return;
                }
                if (val.Length == 3)
                {
                    ((Entry)sender).Text += ") ";
                    return;
                }
                if (val.Length == 9)
                {
                    ((Entry)sender).Text += "-";
                    return;
                }
                if (val.Length == 15)
                {
                    var firstHalf = ((Entry)sender).Text.Substring(0, 10);
                    var secondHalf = ((Entry)sender).Text.Substring(10, 5);

                    ((Entry)sender).Text = firstHalf + "-" + secondHalf;
                    return;
                }

            ((Entry)sender).Text = args.NewTextValue;
            }
        }
    }
}