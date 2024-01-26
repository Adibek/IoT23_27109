using lab3.Database.Entities;


namespace Lab1.Database.Entities

{
    public class PersonEntity
    {
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public Address address{get; set;}
        public int AddressId {get; set;}
    }
}