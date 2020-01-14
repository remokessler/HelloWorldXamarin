using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace HelloWorld.Addresses
{
    public class AddressesListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AddressModel SelectedItem = null;
        public ObservableCollection<AddressModel> Addresses { get; set; }

        public AddressesListViewModel()
        {
            Addresses = AddressService.Instance.Addresses;
        }

        public Action<Page> NavigateToPage = new Action<Page>((Page p) => { });
        private Action<Page, Action<Page>> Navigate = new Action<Page, Action<Page>>((Page p, Action<Page> t) =>
        {
            t.Invoke(p);
        });

        public void Addresses_SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            var col = (CollectionView)sender;
            if (SelectedItem == null && col.SelectedItem == null)
                return;
            var p = new AddressesDetail(((AddressModel)col.SelectedItem).Id);
            Navigate.Invoke(p, NavigateToPage);
            SelectedItem = null;
            PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
        }
    }
}
