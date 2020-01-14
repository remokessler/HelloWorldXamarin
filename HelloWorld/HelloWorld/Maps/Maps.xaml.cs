using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Maps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maps : ContentPage
    {
        public Maps()
        {
            InitializeComponent();
        }

        private async void OpenMapsAtMyLocation(object sender, EventArgs e)
        {

            //await Map.OpenAsync();
        }
    }
}