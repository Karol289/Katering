using System.ComponentModel.DataAnnotations;
namespace Katering.Data.User
{
    public class User
    {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }
    public User() { }

    }
    public enum UserType
    {
        ADMIN, CONTRACTOR, CLIENT, MODERATOR
    }
}
