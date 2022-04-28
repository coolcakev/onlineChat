using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using onlineChat.Base;
using onlineChat.Commands;
using onlineChat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineChat.Configuration
{
    public static class DependencyStartup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {      
            AddInfrastructure(services);
            AddServices(services);         
            AddCommands(services);         
            ConfigureDatabase(services, configuration);
        }

        private static void AddCommands(IServiceCollection services)
        {
            services.AddScoped<IGetChatDependsUserCommand, GetChatDependsUserCommand>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
              options.UseSqlServer(connection));
        }

        private static void AddInfrastructure(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential if you wish
                //options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSignalR();


        }
    }
}
