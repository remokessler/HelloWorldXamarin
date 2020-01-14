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
        private AddressModel _selectedItem = null;
        public AddressModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == _selectedItem) return;
                _selectedItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
                NavigateToDetail();
            }
        }
        public ObservableCollection<AddressModel> Addresses { get; set; }

        public AddressesListViewModel()
        {
            Addresses = AddressService.Instance.Addresses;
        }

        public Action<int> NavigateToPage = new Action<int>((int id) => { });
        private Action<int, Action<int>> Navigate = new Action<int, Action<int>>((int id, Action<int> t) =>
        {
            t.Invoke(id);
        });

        public void NavigateToDetail()
        {
            if (SelectedItem == null) return;

            var id = SelectedItem.Id;
            NavigateToPage(id);
            SelectedItem = null;
        }

        public void Addresses_SelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            var col = (CollectionView)sender;
            if (SelectedItem == null && col.SelectedItem == null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
                return;
            }
            var id = ((AddressModel)col.SelectedItem).Id;
            Navigate.Invoke(id, NavigateToPage);
            SelectedItem = null;
            PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
        }
    }
}
