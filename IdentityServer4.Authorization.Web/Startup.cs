using Framework.Infrastructure.Ioc.Core;
using IdentityServer4.Authorization.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qwerty.DDD.BootStrapping;

namespace IdentityServer4.Authorization.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加数据库连接
            services.Configure(Configuration["data:ConnectionString"]);

            //注入Configuration
            services.AddSingleton(Configuration);
           
            services.AddTransient<IConnectService, ConnectService>();
            
            //注入IdentityServer4
            var builder = services.AddIdentityServer();
            builder.AddInMemoryClients(Clients.Get());
            builder.AddInMemoryIdentityResources(Scopes.GetIdentityScopes());
            builder.AddInMemoryApiResources(Scopes.GetApiScopes());
//            builder.AddProfileService<IProfileService>();
            builder.AddDeveloperSigningCredential();
            builder.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
            //                        builder.AddTestUsers(Clients.GeTestUsers());

            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ServiceLocator.Instance = app.ApplicationServices;

            app.UseIdentityServer();

            app.UseMvc();
        }
    }
}
