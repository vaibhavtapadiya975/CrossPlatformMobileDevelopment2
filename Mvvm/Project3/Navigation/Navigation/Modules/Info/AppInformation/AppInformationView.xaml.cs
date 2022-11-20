using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation.Modules.AppInformation
{
    public partial class AppInformationView : ContentPage
    {
        public AppInformationView(AppInformationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
