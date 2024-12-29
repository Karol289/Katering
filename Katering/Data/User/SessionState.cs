using Katering.Entities;


namespace Katering.Data.SessionState
{
    public class SessionState
    {
        public SessionState() {
            IsLogged = false;
            User = null;
        }

        public bool IsLogged { get; set; }

        public UserEntity? User { get; set; }

        public bool IsAdministration() { return User is AdministrationEntity; }

        public bool IsContractor() { return User is ContractorEntity; }

        public bool IsModerator() { return User is ModeratorEntity; }

        public bool IsClient() { return User is ClientEntity; }

        public void LoginUser(UserEntity userEntity)
        {
            User = userEntity;
            IsLogged = true;
        }
        public void LogoutUser() {
            User = null;
            IsLogged = false;
        }
    }
}
