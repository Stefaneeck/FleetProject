using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace AuthApi.Extensions
{
    #region commentseeddb
    /* Seed db with our InMemoryConfig class data
     * We create scope and use it to migrate all the tables from the PersistedGrantDbContext class. 
     * After that, we create a context for the ConfigurationDbContext class and use the Migrate method to apply migration. 
     * Then we go through all the clients, identity resources, and api resources, add each of them to the context and call the SaveChanges method.
     */
    #endregion
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                using (var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>())
                {
                    try
                    {
                        context.Database.Migrate();
                        if (!context.Clients.Any())
                        {
                            foreach (var client in InMemoryConfig.GetClients())
                            {
                                context.Clients.Add(client.ToEntity());
                            }
                            context.SaveChanges();
                        }
                        if (!context.IdentityResources.Any())
                        {
                            foreach (var resource in InMemoryConfig.GetIdentityResources())
                            {
                                context.IdentityResources.Add(resource.ToEntity());
                            }
                            context.SaveChanges();
                        }
                        if (!context.ApiScopes.Any())
                        {
                            foreach (var apiScope in InMemoryConfig.GetApiScopes())
                            {
                                context.ApiScopes.Add(apiScope.ToEntity());
                            }
                            context.SaveChanges();
                        }
                        if (!context.ApiResources.Any())
                        {
                            foreach (var resource in InMemoryConfig.GetApiResources())
                            {
                                context.ApiResources.Add(resource.ToEntity());
                            }
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
            return host;
        }
    }
}
