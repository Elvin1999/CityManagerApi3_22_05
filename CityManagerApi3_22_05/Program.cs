
using CityManagerApi3_22_05.Data;
using CityManagerApi3_22_05.Data.Abstract;
using CityManagerApi3_22_05.Data.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CityManagerApi3_22_05
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

            builder.Services.AddScoped<IAppRepository, AppRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            var conn = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<AppDataContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });


            var app = builder.Build();

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
