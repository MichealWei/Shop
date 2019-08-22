using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Football", Price = 25, Description = "This is a football", ProductQuantity = 4 },
                    new Product { Name = "Surf board", Price = 36, Description = "It's a surf board", ProductQuantity = 12 },
                    new Product { Name = "Basketball", Price = 86, Description = "Expensive basketball", ProductQuantity = 32 },
                    new Product { Name = "Running shoes", Price = 125, Description = "Amazing running shoes", ProductQuantity = 17 }
                    );
                context.SaveChanges();
            }
        }
    }
}
