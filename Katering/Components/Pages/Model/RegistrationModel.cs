using System.Text.RegularExpressions;
using System.Collections.Generic;

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
        public bool IsPasswordEmpty => string.IsNullOrEmpty(Password);
        public bool IsPasswordVerificationEmpty => string.IsNullOrEmpty(PasswordVerification);

        public bool IsPasswordLengthValid => !IsPasswordEmpty && Password.Length >= 6;

        public List<string> Validate()
        {
            var errors = new List<string>();

            if (!IsEmailFormat)
                errors.Add("Nieprawidłowy format adresu email.");
            if (!ArePasswordsTheSame)
                errors.Add("Hasła nie są zgodne.");
            if (IsPasswordEmpty)
                errors.Add("Hasło jest wymagane.");
            if (!IsPasswordLengthValid)
                errors.Add("Hasło musi zawierać co najmniej 6 znaków.");
            if (IsPasswordVerificationEmpty)
                errors.Add("Powtórzenie hasła jest wymagane.");
            if (!IsNameNotEmpty)
                errors.Add("Imię jest wymagane.");
            if (!IsSurnameNotEmpty)
                errors.Add("Nazwisko jest wymagane.");
            return errors;
        }
    }
}
