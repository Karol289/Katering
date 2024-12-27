namespace Katering.Entities
{
    public class ModeratorEntity(int moderatorId, int moderatorNumber, int id, string name, string surname, string email) : UserEntity(id, name, surname, email)
    {
        public readonly int ModeratorId = moderatorId;

        public int ModeratorNumber { get; set; } = moderatorNumber;
    }
}
