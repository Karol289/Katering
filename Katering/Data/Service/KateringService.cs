using Katering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Katering.Data.Service
{
    public class KateringService
    {
        protected readonly IDbContextFactory<KateringDbContext> _dbContext;
		//private KateringDbContext context;

		public KateringService(IDbContextFactory<KateringDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

		//public KateringService(KateringDbContext context)
		//{
		//	this.context = context;
		//}
	}
}
