using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailingService
{
    public static class MailingServiceExtensions
    {
        public static void AddMailingService(this IServiceCollection services)
        {
            services.AddScoped<IMailingService, MailingService>();
        }
    }
}
