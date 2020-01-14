using HelloWorld.Layouts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace HelloWorld.Layouts.ViewModel
{
    public class LayoutNavViewModel : INotifyPropertyChanged
    {
        public LayoutNavViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        public static INavigation Navigation { get; set; }
        public Action<Page> NavigateTo = (Page p) => { Navigation.PushAsync(p); };

        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<Page> Pages { get => (new LayoutNavModel()).NavEntries; }

    }
}
