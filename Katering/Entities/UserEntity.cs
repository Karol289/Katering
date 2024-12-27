namespace Katering.Entities
{
    public class UserEntity(int id, String name, String surname, String email)
    {
        public readonly int UserId = id; 
        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string Email { get; set; } = email;
       
    }
}
