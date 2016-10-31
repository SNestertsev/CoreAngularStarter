using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CoreAngularStarter.Models;

namespace CoreAngularStarter.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GalleryContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                context.Database.EnsureCreated();

                // Look for any items.
                if (context.CraftItems.Any())
                {
                    return;   // DB has been seeded already
                }

                var categories = new Category[]
                {
                new Category { Name="Bracelets", Description="Rubber bands to wear on the arm" },
                new Category { Name="Figures 2D", Description="" }
                };
                foreach (Category category in categories)
                {
                    context.Categories.Add(category);
                }

                var craftItems = new CraftItem[]
                {
                new CraftItem { Name = "Item1", Description="Item 1 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item2", Description="Item 2 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item3", Description="Item 3 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item4", Description="Item 4 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item5", Description="Item 5 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item6", Description="Item 6 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item7", Description="Item 7 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item8", Description="Item 8 description", ImageUrl="", Available=true },
                new CraftItem { Name = "Item9", Description="Item 9 description", ImageUrl="", Available=true },
                };
                foreach (CraftItem item in craftItems)
                {
                    context.CraftItems.Add(item);
                }

                int braceletsCategory = categories.Single(cat => cat.Name == "Bracelets").ID;
                int figures2dCategory = categories.Single(cat => cat.Name == "Figures 2D").ID;
                var categoryItems = new CategoryItem[]
                {
                new CategoryItem { CategoryID=braceletsCategory, CraftItemID=craftItems.Single(item => item.Name == "Item1").ID },
                new CategoryItem { CategoryID=braceletsCategory, CraftItemID=craftItems.Single(item => item.Name == "Item3").ID },
                new CategoryItem { CategoryID=braceletsCategory, CraftItemID=craftItems.Single(item => item.Name == "Item4").ID },
                new CategoryItem { CategoryID=braceletsCategory, CraftItemID=craftItems.Single(item => item.Name == "Item5").ID },
                new CategoryItem { CategoryID=figures2dCategory, CraftItemID=craftItems.Single(item => item.Name == "Item2").ID },
                new CategoryItem { CategoryID=figures2dCategory, CraftItemID=craftItems.Single(item => item.Name == "Item6").ID },
                new CategoryItem { CategoryID=figures2dCategory, CraftItemID=craftItems.Single(item => item.Name == "Item1").ID },
                new CategoryItem { CategoryID=figures2dCategory, CraftItemID=craftItems.Single(item => item.Name == "Item7").ID },
                new CategoryItem { CategoryID=figures2dCategory, CraftItemID=craftItems.Single(item => item.Name == "Item8").ID }
                };
                foreach (CategoryItem relItem in categoryItems)
                {
                    context.CategoryItems.Add(relItem);
                }

                context.SaveChanges();
                loggerFactory.CreateLogger("DbInitializer").LogInformation("Db initialization succeeded");
            }
            catch (Exception ex)
            {
                loggerFactory.CreateLogger("DbInitializer").LogError(0, ex, "Db initialization failure");
            }
        }
    }
}
