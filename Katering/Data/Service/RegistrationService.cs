using Katering.Components.Pages.Model;
using Katering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Katering.Data.Service
{
	public class RegistrationService : KateringService
	{
		private readonly IDbContextFactory<KateringDbContext> dbContext;
		public RegistrationService(IDbContextFactory<KateringDbContext> dbContext) : base(dbContext)
		{
			this.dbContext = dbContext;
		}
		public RegistrationResult RegisterClient(RegistrationModel model)
		{
			using (var context = dbContext.CreateDbContext())
			{
				try
				{
					var exsitingUser = context.Users.Where(user => user.Email == model.Email).FirstOrDefault();
					if (exsitingUser == null)
					{
						var newUser = new User.User
						{
							Email = model.Email,
							Name = model.Name,
							Password = model.Password,
							Surname = model.Surname,
							Type = User.UserType.CLIENT,
						};
						context.Users.Add(newUser);
						context.SaveChanges();
						return RegistrationResult.SUCCESS;
					}
					else
					{
						return RegistrationResult.ALREADY_REGISTERED;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					return RegistrationResult.ERROR;
				}
			}

		}
	}
}

public enum RegistrationResult
	{
		SUCCESS,
		ALREADY_REGISTERED,
		ERROR
	}