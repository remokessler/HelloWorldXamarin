using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Addresses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressesDetail : ContentPage
    {
        private AddressesDetailViewModel advm { get; set; }
        public AddressesDetail(int id)
        {
            InitializeComponent();
            advm = new AddressesDetailViewModel(id);
            BindingContext = advm;
        }

        protected override void OnDisappearing()
        {
            advm.SaveAndNotifyOnPageLeave();
            base.OnDisappearing();
        }
    }
}