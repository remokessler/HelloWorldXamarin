using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HelloWorld.Addresses
{
    public class AddressesDetailViewModel : INotifyPropertyChanged
    {
        private AddressModel address { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get => address.Id;
            private set
            {
                if (address.Id == value) return;
                address.Id = value;
                PropertyChanged(address, new PropertyChangedEventArgs("Id"));
            }
        }

        public string Firstname 
        { 
            get => address.Firstname;
            set 
            {
                if (address.Firstname == value) return;
                address.Firstname = value;
                PropertyChanged(address, new PropertyChangedEventArgs("Firstname"));
            }
        }
        public string Lastname
        { 
            get => address.Lastname;
            set 
            {
                if (address.Lastname == value) return;
                address.Lastname = value;
                PropertyChanged(address, new PropertyChangedEventArgs("Lastname"));
            }
        }
        public DateTime Birthdate
        {
            get => address.Birthdate;
            set
            {
                if (address.Birthdate == value) return;
                address.Birthdate = value;
                PropertyChanged(address, new PropertyChangedEventArgs("Birthdate"));
            }
        }
        public string Street
        {
            get => address.Street;
            set
            {
                if (address.Street == value) return;
                address.Street = value;
                PropertyChanged(address, new PropertyChangedEventArgs("Street"));
            }
        }

        public AddressesDetailViewModel(AddressModel am)
        {
            address = am;
        }

        public AddressesDetailViewModel(int id)
        {
            address = AddressService.Instance.GetAddressById(id);
        }

        public void Save()
        {
            AddressService.Instance.UpdateAddress(address);
        }

    }
}
