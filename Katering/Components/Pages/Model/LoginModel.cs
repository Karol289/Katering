namespace Katering.Components.Pages.Model
{
    public class LoginModel
    {
        public String Login { get; set; }
        public String Password { get; set; }

        public LoginResult LoginResult { get; set; }

        public bool IsPasswordEmpty => String.IsNullOrEmpty(Password);

        public bool IsLoginEmpty => String.IsNullOrEmpty(Login);
    }
}
public enum LoginResult
{
    SUCCESS, UNKNOWN_EMAIL, ERROR
}
