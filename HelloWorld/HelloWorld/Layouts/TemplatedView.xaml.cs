using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TemplatedView : ContentPage
    {
        public TemplatedView()
        {
            InitializeComponent();
        }
    }
}