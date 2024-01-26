using CdvAzure.Functions;
using lab3.Database.Entities;

namespace lab3
{
    public interface IAddressesServices
    {
        Address FindAddress(int id);

        IEnumerable<Address> GetAddresses();

        Address AddAddress(Address address);
    }
}