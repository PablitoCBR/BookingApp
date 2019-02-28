using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using BookingApp.Interfaces.Services.Accounts;
using BookingApp.Helpers;
using BookingApp.Contextes;
using BookingApp.Services.Accounts;
using BookingApp.Dtos.Accounts;
using BookingApp.Security;
using BookingApp.Repositories;
using BookingApp.Interfaces.Repositories;
using BookingApp.Interfaces.Security;
using BookingApp.Entities.Accounts;

namespace BookingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.AddDbContext<AccountsContext>(options => options.UseSqlite(Configuration.GetConnectionString("AccountsDbContext")));
           
            // configure strongly typed settings objects
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if(context.Principal.HasClaim(c => c.Value == Role.User))
                        {
                            IUserService userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                            int userId = int.Parse(context.Principal.Identity.Name);
                            UserDto user = userService.Get(userId);
                            if (user == null)
                                context.Fail("Unauthorized");
                            return Task.CompletedTask;
                        }
                        else
                        {
                            IBusinessService businessService = context.HttpContext.RequestServices.GetRequiredService<IBusinessService>();
                            int userId = int.Parse(context.Principal.Identity.Name);
                            BusinessDto business = businessService.Get(userId);
                            if (business == null)
                                context.Fail("Unauthorized");
                            return Task.CompletedTask;
                        }
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //DI for app services
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IPasswordHandler, PasswordHandler>();
            services.AddSingleton<JWTProvider>();
            services.AddScoped(typeof(IAccountManager<>), typeof(AccountManager<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AddressValidator>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IBusinessService, BusinessService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // global CORS policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
