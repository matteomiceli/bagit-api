namespace bagit_api.Data;
using bagit_api.Models;

public class SeedData
{
    public static async void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BagItDbContext>();
                context.Database.EnsureCreated();

                // Look for any teams.
                if (context.MockShoppingList.Any())
                {
                    return;   // DB has already been seeded
                }

                var list = GetList();
                context.MockShoppingList.Add(list);
                context.SaveChanges();
            }
        } 
    public static MockShoppingList GetList() {
        MockShoppingList list = new MockShoppingList()
        {   
            Name =  "new list",
        };
        return list;
    }
}