using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.Addresses
{
    public class AddressesDetailViewModel : INotifyPropertyChanged
    {
        private AddressModel _address { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get => _address.Id;
            private set
            {
                if (_address.Id == value) return;
                _address.Id = value;
                PropertyChanged(_address, new PropertyChangedEventArgs("Id"));
            }
        }
        public string Firstname 
        { 
            get => _address.Firstname;
            set 
            {
                if (_address.Firstname == value) return;
                _address.Firstname = value;
                PropertyChanged(_address, new PropertyChangedEventArgs("Firstname"));
            }
        }
        public string Lastname
        { 
            get => _address.Lastname;
            set 
            {
                if (_address.Lastname == value) return;
                _address.Lastname = value;
                PropertyChanged(_address, new PropertyChangedEventArgs("Lastname"));
            }
        }
        public DateTime Birthdate
        {
            get => _address.Birthdate;
            set
            {
                if (_address.Birthdate == value) return;
                _address.Birthdate = value;
                PropertyChanged(_address, new PropertyChangedEventArgs("Birthdate"));
            }
        }
        public string Street
        {
            get => _address.Street;
            set
            {
                if (_address.Street == value) return;
                _address.Street = value;
                PropertyChanged(_address, new PropertyChangedEventArgs("Street"));
            }
        }

        public AddressesDetailViewModel(AddressModel am)
        {
            _address = am;
            SaveBtnPressed = new Command(() => _modify(() => AddressService.Instance.CreateAddress(_address), NavigateBack));
            Init();
        }

        public AddressesDetailViewModel(int id)
        {
            _address = AddressService.Instance.GetAddressById(id);
            SaveBtnPressed = new Command(() => _modify(() => AddressService.Instance.UpdateAddress(_address), NavigateBack));
            Init();
        }

        private void Init()
        {
            DeleteBtnPressed = new Command(() => _modify(() => AddressService.Instance.DeleteAddress(Id), NavigateBack));
            Swiped = new Command(() => NavigateBack());
        }

        public Action NavigateBack = new Action(() => { });
        private Action<Action, Action> _modify = new Action<Action, Action>((Action crud, Action nav) => {
            crud();
            nav();
        });

        public ICommand SaveBtnPressed { get; set; }
        public ICommand DeleteBtnPressed { get; set; }
        public ICommand Swiped { get; set; }
    }
}
