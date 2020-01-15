using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Addresses
{
    public class AddressDataAccess
    {
        private static AddressDataAccess _instance;
        public static AddressDataAccess Instance => _instance ?? (_instance = new AddressDataAccess(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Address.db3")));
        private readonly SQLiteAsyncConnection _dataBase;
        private AddressDataAccess(string dbPath)
        {
            _dataBase = new SQLiteAsyncConnection(dbPath);
            _dataBase.CreateTableAsync<AddressModel>().Wait();
        }

        public Task<List<AddressModel>> GetAllAddresses()
        {
            return _dataBase.Table<AddressModel>().ToListAsync();
        }

        public Task<AddressModel> GetAddressById(int id)
        {
            return _dataBase.Table<AddressModel>().FirstAsync(table => table.Id == id);
        }

        public Task<int> SaveAddress(AddressModel am)
        {
            if(am.Id == 0)
                return _dataBase.InsertAsync(am);
            else 
                return _dataBase.UpdateAsync(am);
        }

        public Task<int> DeleteAddress(AddressModel am)
        {
            return _dataBase.DeleteAsync(am);
        }
    }
}
