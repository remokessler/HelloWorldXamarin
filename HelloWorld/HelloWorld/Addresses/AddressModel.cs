using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Addresses
{
    public class AddressModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Street { get; set; }
    }
}
