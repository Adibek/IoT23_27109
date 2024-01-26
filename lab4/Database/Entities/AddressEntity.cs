using Lab1.Database.Entities;

namespace lab3.Database.Entities
{
    public class Address
    {
        public int AddressId{get;set;}
        public string City {get; set;}
        public string AddressLine {get; set;}
        public List<PersonEntity> people {get; set;}
    }
}