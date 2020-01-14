using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Addresses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressesList : ContentPage
    {
        private AddressesListViewModel alvm = new AddressesListViewModel();
        public AddressesList()
        {
            InitializeComponent();
            BindingContext = alvm;
            AddressList.SelectionChanged += alvm.Addresses_SelectedItemChanged;
            alvm.NavigateToPage = (Page p) => Navigation.PushAsync(p);
        }
    }
}