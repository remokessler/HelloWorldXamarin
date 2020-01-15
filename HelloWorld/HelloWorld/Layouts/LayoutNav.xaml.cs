using HelloWorld.Layouts.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Addresses : ContentPage
    {
        private LayoutNavViewModel lnvm { get; set; }
        public ObservableCollection<Page> Pages { get; set; }
        
        public Addresses()
        {
            InitializeComponent();
            lnvm = new LayoutNavViewModel(Navigation);
            //Pages = new ObservableCollection<Page>(lnvm.Pages);
            BindingContext = Pages;
        }

        private void NavigateTo(object sender, System.EventArgs e)
        {
            // lnvm.NavigateTo(BindingContext.);
        }
    }
}