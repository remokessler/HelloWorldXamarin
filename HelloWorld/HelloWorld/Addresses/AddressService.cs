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
            Addresses = new ObservableCollection<AddressModel>(new AddressModel[]
            {
                new AddressModel()
                {
                    Id = 1,
                    Firstname = "Max",
                    Lastname = "Muster",
                    Birthdate = new DateTime(1950, 1,1),
                    Street = "Musterstrasse 3"
                },
                new AddressModel()
                {
                    Id = 2,
                    Firstname = "Fritzli",
                    Lastname = "Muster",
                    Birthdate = new DateTime(2000,2,2),
                    Street = "Musterstrasse 28"
                },
                new AddressModel()
                {
                    Id = 3,
                    Firstname = "Vreni",
                    Lastname = "Muster",
                    Birthdate = new DateTime(1980, 3, 3),
                    Street = "Musterstrasse 12"
                }
            });
        }

        public AddressModel GetAddressById(int id)
        {
            return Addresses.First(add => add.Id == id);
        }

        public void DeleteAddress(AddressModel am)
        {
            Addresses.Remove(am);
            CrudNotificatorEventHandler(am, new CrudEventArgs(Change.Delete));
        }

        public void Create(AddressModel am)
        {
            var ids = Addresses.Select(a => a.Id).OrderBy(a => a);
            var firstMissing = Enumerable.Range(1, ids.Last() + 1).Where(i => !ids.Contains(i)).First();
            am.Id = firstMissing;
            Addresses.Add(am);
            CrudNotificatorEventHandler(am, new CrudEventArgs(Change.Create));
        }

        public void UpdateAddress(AddressModel am)
        {
            var index = Addresses.IndexOf(Addresses.First(a => a.Id == am.Id));
            Addresses[index] = am;
            CrudNotificatorEventHandler(am, new CrudEventArgs(Change.Update));
        }
    }
}
