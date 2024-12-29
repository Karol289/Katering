

using System.Text.RegularExpressions;

namespace Katering.Components.Pages.Model
{
    public class RegistrationModel
    {
        public String Email { get; set; }
        public String Password { get; set; }

        public String PasswordVerification {  get; set; }

        public String Name { get; set; }

        public String Surname { get; set; }

        public bool ArePasswordsTheSame => Password == PasswordVerification;

        public bool IsEmailNotEmpty => !String.IsNullOrEmpty(Email);

        public bool IsNameNotEmpty => !String.IsNullOrEmpty(Name);

        public bool IsSurnameNotEmpty => !String.IsNullOrEmpty(Surname);

        public bool IsEmailFormat => Regex.IsMatch(Email,
            @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            RegexOptions.IgnoreCase);

        public bool IsPasswordEmpty => String.IsNullOrEmpty(Password);

        public bool IsPasswordVerifcationEmpty => String.IsNullOrEmpty(PasswordVerification);
        public bool IsModleValid()
        {
            return ArePasswordsTheSame && IsEmailNotEmpty && IsNameNotEmpty && IsSurnameNotEmpty && IsEmailFormat;
        }
    }
}
