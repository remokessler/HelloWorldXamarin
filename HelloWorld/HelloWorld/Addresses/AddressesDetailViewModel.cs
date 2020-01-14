using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HelloWorld.Addresses
{
    public class AddressesDetailViewModel : INotifyPropertyChanged
    {
        private const string _lastname = "Lastname";
        private const string _firstname = "Firstname";
        private const string _birthdate = "Birthdate";
        private const string _street = "Street";

        private AddressModel address { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private List<string> IsDirty = new List<string>();

        public string Firstname 
        { 
            get => address.Firstname;
            set 
            {
                address.Firstname = value;
                if (!IsDirty.Contains(_firstname))
                    IsDirty.Add(_firstname);
            }
        }
        public string Lastname
        { 
            get => address.Lastname;
            set 
            {
                address.Lastname = value;
                if (!IsDirty.Contains(_lastname))
                    IsDirty.Add(_lastname);
            }
        }
        public DateTime Birthdate
        {
            get => address.Birthdate;
            set
            {
                address.Birthdate = value;
                if (!IsDirty.Contains(_birthdate))
                    IsDirty.Add(_birthdate);
            }
        }
        public string Street
        {
            get => address.Street;
            set
            {
                address.Street = value;
                if (!IsDirty.Contains(_street))
                    IsDirty.Add(_street);
            }
        }

        public AddressesDetailViewModel(int id)
        {
            address = AddressService.Instance.GetAddressById(id);
        }

        public void SaveAndNotifyOnPageLeave()
        {
            if(IsDirty?.Count > 0)
            {
                AddressService.Instance.ReplaceAddress(address, PropertyChanged);
                IsDirty.ForEach(name => PropertyChanged(this, new PropertyChangedEventArgs(name)));
            }
        }

    }
}
