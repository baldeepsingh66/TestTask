using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestTask.AutoMapper;
using TestTask.IService;
using TestTask.Repository;
using TestTask.Service;

namespace TestTask
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SupplierAMProfile());
                mc.AddProfile(new HotelAMProfile());
            });
            // Add your services here
            services.AddDbContext<TestTask.AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Truck ERP System API",
                    Version = "v2",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "Baldeep Singh",
                        Email = "baldeepsingh66@gmail.com",
                    },
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {{ new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
                }});
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IAddressServices, AddressServices>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            string configuredOrigins = Configuration["AllowedHosts"] ?? throw new ArgumentNullException("AllowedHosts");
            string[] origins = configuredOrigins.Split(',', ';').Select(i => i.Trim()).ToArray();
            app.UseCors(policy => policy
                .WithOrigins(origins)
                .AllowAnyMethod()
                .AllowAnyHeader());
            //app.UseAuthentication();
            //app.UseAuthorization();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "Truck ERP System API");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
