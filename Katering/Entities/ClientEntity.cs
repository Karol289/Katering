namespace Katering.Entities
{
    public class ClientEntity(int clientId, string city, string street, string houseNumber, string phoneNumber, int id, string name, string surname, string email) : UserEntity(id, name, surname, email)
    {
        public readonly int ClientId = clientId;
        public string City { get; set; } = city;
        public string Street { get; set; } = street;
        public string HouseNumber { get; set; } = houseNumber;
        public string PhoneNumber { get; set; } = phoneNumber;
    }
}
