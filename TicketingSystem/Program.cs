using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicketingSystem.Shared.Common;

namespace TicketingSystem
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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Add JWT Authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token.\n\nExample: \"Bearer eyJhbGci...\""
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                                new string[] {}
                            }
                        });
            });

            builder.Services.AddAuthorization();

            builder.Services.PersistanceDependancies(builder.Configuration);
            builder.Services.Services();
				
			builder.Services.AddCors(options =>
						{
							options.AddPolicy("AllowAngularApp", policy =>
							{
								policy.WithOrigins("http://localhost:4200") // Angular app URL
									  .AllowAnyMethod()
									  .AllowAnyHeader()
									  .AllowCredentials(); // Needed if using cookies/auth
							});
						});	
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                        .AddJwtBearer(options =>
                        {


                            options.TokenValidationParameters = new TokenValidationParameters()
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSecret") ?? " ")),
                                ValidateIssuer = false,
                                ValidateAudience = false
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
            app.UseAuthentication();
            app.UseAuthorization();

			app.UseCors("AllowAngularApp");
            app.MapControllers();

            app.Run();
        }
    }
}
