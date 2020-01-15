using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace HelloWorld.Addresses
{
    public class AddressService
    {
        private static AddressService instance;
        public static AddressService Instance => instance ?? (instance = new AddressService());

        public ObservableCollection<AddressModel> Addresses { get; private set; }
        public event EventHandler<CrudEventArgs> CrudNotificatorEventHandler;

        private AddressService()
        {
            RefreshAddresses();
        }

        private void RefreshAddresses()
        {
            Addresses = new ObservableCollection<AddressModel>(AddressDataAccess.Instance.GetAllAddresses().Result);
        }

        public AddressModel GetAddressById(int id)
        {
            return AddressDataAccess.Instance.GetAddressById(id).Result;
        }

        public void DeleteAddress(AddressModel am)
        {
            AddressDataAccess.Instance.DeleteAddress(am);
            Addresses.Remove(am);
            CrudNotificatorEventHandler(am, new CrudEventArgs(Change.Delete));
        }

        public void SaveAddress(AddressModel am)
        {
            AddressDataAccess.Instance.SaveAddress(am);
            if(am.Id != 0 && Addresses.Any(a => a.Id == am.Id))
            {
                var index = Addresses.IndexOf(Addresses.First(a => a.Id == am.Id));
                Addresses[index] = am;
            }
            else
                RefreshAddresses();
            
            CrudNotificatorEventHandler(am, new CrudEventArgs(Change.Create));
        }
    }
}
