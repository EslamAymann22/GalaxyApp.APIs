
using GalaxyApp.Core;
using GalaxyApp.Core.MiddleWare;
using GalaxyApp.Data.Entities.Identity;
using GalaxyApp.Infrastructure;
using GalaxyApp.Infrastructure.DataSeeding;
using GalaxyApp.Infrastructure.DbContextData;
using GalaxyApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace GalaxyApp.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<GalaxyDbContext>(Options =>
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddIdentity<AppUser, IdentityRole>(Options =>
            {
                Options.Password.RequireUppercase = false;
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireDigit = false;
                Options.Password.RequireLowercase = false;
                Options.User.RequireUniqueEmail = true;


            }).AddEntityFrameworkStores<GalaxyDbContext>();

            builder.Services.AddInfrastructureDependencies()
                            .AddServicesDependencies()
                            .AddCoreDependencies()
                            .AddJWTTokenConfigurations(builder.Configuration);






            var app = builder.Build();


            #region AutoDatabaseUpdate 
            using var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try
            {
                var DbContext = Services.GetRequiredService<GalaxyDbContext>();
                await DbContext.Database.MigrateAsync();

                var UserManager = Services.GetRequiredService<UserManager<AppUser>>();
                var RoleManager = Services.GetRequiredService<RoleManager<IdentityRole>>();
                await DataSeed.AddDataSeedAsync(DbContext, UserManager, RoleManager);

            }
            catch (Exception ex)
            {

                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "Error During Update database in Program\n");

            }
            #endregion


            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
