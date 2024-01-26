using System.Collections;
using CdvAzure.Functions;
using Lab1.Database;
using lab3.Database;
using lab3.Database.Entities;

namespace lab3.Services
{
    public class DatabaseAddressesService: IAddressesServices
    {
        private readonly PeopleDb db;

        public DatabaseAddressesService(PeopleDb db)
        {
            this.db = db;
        }
        public Address AddAddress(Address address){
            var entity = new Address
            {
                City = address.City,
                AddressLine = address.AddressLine
            };
            db.Address.Add(entity);
            db.SaveChanges();
            address.AddressId = entity.AddressId;
            return address;
        }
        public IEnumerable<Address> GetAddresses()
        {
            var addressesList = db.Address.Select(s => new Address
            {
                AddressId = s.AddressId,
                City = s.City,
                AddressLine = s.AddressLine
            });

            return addressesList;
        }

        Address IAddressesServices.FindAddress(int id)
        {
            var address = db.Address.First(w=>w.AddressId == id);
            return MapToDTO(address);
        }
        public Address MapToDTO(Address entity){
            return new Address
            {
                City = entity.City,
                AddressLine = entity.AddressLine,
                AddressId = entity.AddressId
            };
        }
    }
}