using System;
using Xamarin.Forms;

namespace HelloWorld.Layouts.ViewModel
{
    public class LayoutNavViewModel
    {
        public LayoutNavViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public static INavigation Navigation { get; set; }
        public Action<Page> NavigateTo = (Page p) => { Navigation.PushAsync(p); };

        //public IEnumerable<Page> Pages { get => new LayoutNavModel().NavEntries; }

    }
}
