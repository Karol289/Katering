using Katering.Components.Pages.Model;
using Katering.Data.Users;
using Katering.Entities;
using Microsoft.EntityFrameworkCore;
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
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = await context.Users
                    .Where(u => u.Email == loginModel.Login && u.Password == loginModel.Password)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return LoginResult.UNKNOWN_EMAIL;
                }
                else
                {
                    var userEntity = MapToEntity(user, context);
                    _sessionState.LoginUser(userEntity);
                    return LoginResult.SUCCESS;
                }
            }
        }

        private UserEntity MapToEntity(User user, KateringDbContext context)
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
                    var contractor = context.Contractors.Where(c=>c.UserId== user.Id).FirstOrDefault();
                        if(contractor == null)
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
                        var client = context.Clients.Where(c=>c.UserId == user.Id).FirstOrDefault();
                        if(client == null)
                        {
                            throw new InvalidOperationException("Nie znaleziono danych klienta");
                        }
                        return new ClientEntity(
                        clientId: client.Id,
                            city: client.City,
                            street: client.Street,
                            houseNumber: client.HouseNumber,
                            phoneNumber: client.PhoneNumber,
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