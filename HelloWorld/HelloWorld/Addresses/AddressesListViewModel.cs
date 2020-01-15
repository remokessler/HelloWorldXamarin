using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.Addresses
{
    public class AddressesListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AddressesDetailViewModel _selectedItem = null;
        public AddressesDetailViewModel SelectedItem
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
        public ObservableCollection<AddressesDetailViewModel> Addresses { get; set; }

        public AddressesListViewModel()
        {
            AddressService.Instance.CrudNotificatorEventHandler += CrudNotificationHandler;
            Addresses = new ObservableCollection<AddressesDetailViewModel> (AddressService.Instance.Addresses.Select(am => new AddressesDetailViewModel(am)));
            AddNew = new Command(() => OpenNewPage());
        }

        private void CrudNotificationHandler(object sender, CrudEventArgs e)
        {
            var am = (AddressModel)sender;
            if (e.Change == Change.Update)
            {
                var id = Addresses.IndexOf(Addresses.First(advm => advm.Id == ((AddressModel)sender).Id));
                Addresses[id] = new AddressesDetailViewModel(am);
                PropertyChanged(Addresses.First(advm => advm.Id == am.Id), new PropertyChangedEventArgs("Addresses"));
            }
            else if (e.Change == Change.Create)
                Addresses.Add(new AddressesDetailViewModel(am));
            else if (e.Change == Change.Delete)
                Addresses.Remove(Addresses.First(advm => advm.Id == am.Id));
        }

        public Action<int> NavigateToPage = new Action<int>((int id) => { });
        public Action OpenNewPage = new Action(() => { });
        private Action<int, Action<int>> Navigate = new Action<int, Action<int>>((int id, Action<int> t) =>
        {
            t.Invoke(id);
        });

        public void NavigateToDetail()
        {
            if (SelectedItem == null) return;

            var id = SelectedItem.Id;
            Navigate(id, NavigateToPage);
            SelectedItem = null;
        }

        public ICommand AddNew { get; set; }
    }
}
