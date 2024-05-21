using Company.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Company
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure configuration
            builder.Configuration.AddJsonFile("appsettings.json");

            // Add services to the container.
            ConfigureCompanyServices(builder.Services, builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }

        private static void ConfigureCompanyServices(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureEfCore(services, configuration);
            ConfigureApplication(services);
        }

        private static void ConfigureApplication(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EmployeesApplicationAutoMapperProfile));

            services.AddTransient<IEmployeeAppService, EmployeeAppService>();
        }

        private static void ConfigureEfCore(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeesDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddTransient<IEmployeeRepository, EfCoreEmployeeRepository>();
        }
    }
}
