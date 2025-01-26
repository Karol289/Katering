using Katering.Components.Pages.Model;
using Katering.Data.Users;
using Katering.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Contracts;

namespace Katering.Data.Service
{
    public class UserService : KateringService
    {
        private readonly IDbContextFactory<KateringDbContext> _dbContextFactory;
        private readonly Katering.Data.SessionState.SessionState _sessionState;  // Pełna ścieżka

        public UserService(IDbContextFactory<KateringDbContext> dbContextFactory, Katering.Data.SessionState.SessionState sessionState) : base(dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _sessionState = sessionState;
        }
        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            // Walidacja danych wejściowych
            if (string.IsNullOrEmpty(loginModel.Login) || string.IsNullOrEmpty(loginModel.Password))
            {
                return LoginResult.ERROR; // Dane logowania są niekompletne
            }

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Login);

                if (user == null)
                {
                    return LoginResult.UNKNOWN_EMAIL;
                }
                // Sprawdź poprawność hasła
                if (user.Password != loginModel.Password)
                {
                    return LoginResult.ERROR; // Hasło jest nieprawidłowe
                }

                // Mapowanie na odpowiedni typ użytkownika
                var userEntity = MapToEntityAsync(user, context);

                // Zaloguj użytkownika do sesji
                _sessionState.LoginUser(userEntity);

                return LoginResult.SUCCESS;
            }
        }

        private UserEntity MapToEntityAsync(User user, KateringDbContext context)
        {
            switch (user.Type)
            {
                case UserType.ADMIN:
                    { return new AdministrationEntity(user.Id, user.Name, user.Surname, user.Email); }
                case UserType.MODERATOR:
                    {
                        var moderator = context.Moderators.Where(m => m.UserId == user.Id).FirstOrDefault();
                        if (moderator == null)
                        {
                            throw new InvalidOperationException("Nie znaleziono danych moderatora");
                        }
                        return new ModeratorEntity(
                            moderatorId: moderator.Id,
                            moderatorNumber: moderator.ModeratorNumber,
                            id: user.Id,
                            name: user.Name,
                            surname: user.Surname,
                            email: user.Email);
                    }
                case UserType.CONTRACTOR:
                    {
                        var contractor = context.Contractors.Where(c => c.UserId == user.Id).FirstOrDefault();
                        if (contractor == null)
                        {
                            throw new InvalidOperationException("Nie znaleziono danych kontrahenta");
                        }
                        return new ContractorEntity(
                            contractorId: contractor.Id,
                            companyName: contractor.CompanyName,
                            NIP: contractor.NIP,
                            id: user.Id,
                            name: user.Name,
                            surname: user.Surname,
                            email: user.Email);
                    }
                case UserType.CLIENT:
                    {
                        if (context.Clients.IsNullOrEmpty()) {
                            return ClientEntity.CreateNotFullyRegistered(user.Id, user.Name, user.Surname, user.Email);
                        }
                        
                        var client = context.Clients.Where(c => c.UserId == user.Id).First();
                        if (client == null)
                        {
                            return ClientEntity.CreateNotFullyRegistered(user.Id, user.Name, user.Surname, user.Email);
                        }
                        return new ClientEntity(
                            clientId: client.Id,
                                city: client.City.OrEmpty(),
                                street: client.Street.OrEmpty(),
                                houseNumber: client.HouseNumber.OrEmpty(),
                                phoneNumber: client.PhoneNumber.OrEmpty(),
                                id: user.Id,
                                name: user.Name,
                                surname: user.Surname,
                                email: user.Email);
                    }

                default:
                    throw new ArgumentOutOfRangeException("Nieznany typ użytkownika.");

            }
        }
    }
}

public static class StringExtensions
{
    public static string OrEmpty(this string? source)
    {
        return source ?? string.Empty;
    }
}
