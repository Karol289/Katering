namespace Katering.Components.Pages.Model
{
    public class LoginModel
    {
        public String Login { get; set; }
        public String Password { get; set; }

        public LoginResult LoginResult { get; set; }

        public bool IsPasswordEmpty => String.IsNullOrEmpty(Password);

        public bool IsLoginEmpty => String.IsNullOrEmpty(Login);


        public List<string> Validate()
        {
            var errors = new List<string>();

            if (IsLoginEmpty)
                errors.Add("Login jest wymagany.");
            if (IsPasswordEmpty)
                errors.Add("Hasło jest wymagane.");
            return errors;
        }
    }
}
public enum LoginResult
{
    SUCCESS, UNKNOWN_EMAIL, ERROR
}
