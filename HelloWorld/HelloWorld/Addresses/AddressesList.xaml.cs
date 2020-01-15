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
            alvm.NavigateToPage = (int id) => Navigation.PushAsync(new AddressesDetail(id));
            alvm.OpenNewPage = () => Navigation.PushAsync(new AddressesDetail());
        }
    }
}