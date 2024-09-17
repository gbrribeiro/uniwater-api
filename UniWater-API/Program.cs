
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniWater_API.Data;
using UniWater_API.Models.Identity;
using UniWater_API.Worker.Interfaces;
using Compacts.Simple.Identity.EF.Extensions;
using Compacts.Simple.Identity.EF;

namespace UniWater_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));

            builder.Services.AddCustomServices();

            //Identity
            builder.Services.AddCompactIdentity<AppUser, IdentityRole, DatabaseContext>(db => db.UseSqlite(builder.Configuration.GetConnectionString("SQLite")));
            builder.Services.AddJwt(builder.Configuration);
            builder.Services.AddJwtVerificationSwagger();

            var app = builder.Build();

            //Hangfire dashboard
            app.UseHangfireDashboard();
            using (var scope = app.Services.CreateScope())
            {
                var batchFactory = scope.ServiceProvider.GetRequiredService<IBatchFactory>();
                batchFactory.StartHangfire();
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}