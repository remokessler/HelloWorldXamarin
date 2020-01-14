using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace HelloWorld.Addresses
{
    public class AddressService
    {
        private static AddressService instance;
        public static AddressService Instance
        {
            get
            {
                if (instance == null)
                    instance = new AddressService();
                return instance;
            }
        }

        public ObservableCollection<AddressModel> Addresses { get; }
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

        public void ReplaceAddress(AddressModel am, PropertyChangedEventHandler e)
        {
            var index = Addresses.IndexOf(Addresses.First(a => a.Id == am.Id));
            Addresses[index] = am;
            e(Addresses, new PropertyChangedEventArgs("Addresses"));
        }
    }
}
