namespace CdvAzure.Functions
{
    public class AddressService
    {
        private List<AddressServiceEntity> addresses {get;} = new List<AddressServiceEntity>();
        public AddressServiceEntity Add(string city, string addressLine)
        {
            var address = new AddressServiceEntity
            {
                City = city,
                AddressLine = addressLine,
                Id = addresses.Count + 1
            };
            addresses.Add(address);
            return address;
        }

        public AddressServiceEntity Update(int id, string city, string addressLine)
        {
            var address = addresses.First(w => w.Id == id);
            address.City = city;
            address.AddressLine = addressLine;

            return address;
        }

        public void Delete(int id)
        {
            var address = addresses.First(w => w.Id ==id);
            addresses.Remove(address);
        }

        public AddressServiceEntity Find(int id)
        {
            return addresses.First(w => w.Id == id);
        }

        public IEnumerable<AddressServiceEntity> Get()
        {
            return addresses;
        }
    }
    public class AddressServiceEntity
    {
        public int Id {get; set;}
        public string City {get; set;}
        public string AddressLine {get; set;}
    }
}