using System.Threading.Tasks;
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
            advm.NavigateBack = new System.Action(() => Navigation.PopAsync());
            BindingContext = advm;
            DeleteButton.IsVisible = true;
        }
        public AddressesDetail()
        {
            InitializeComponent();
            advm = new AddressesDetailViewModel(new AddressModel());
            advm.NavigateBack = new System.Action(() => Navigation.PopAsync());
            BindingContext = advm;
            DeleteButton.IsVisible = false;
        }

        private void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            //My Super Easteregg
            Background.BackgroundColor = Color.HotPink;
        }
    }
}