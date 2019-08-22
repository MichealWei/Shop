using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class EFUserRepository : IUserRepository
    {
        private AppIdentityDbContext context;

        public EFUserRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Customer> Users => context.Customers;
    }
}
