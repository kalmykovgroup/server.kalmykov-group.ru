
using KalmykovGroup.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KalmykovGroup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container. 

            #if DEBUG
                        builder.Configuration.AddJsonFile("settings.Development.json", optional: true, reloadOnChange: true);
            #else
                        builder.Configuration.AddJsonFile("settings.json", optional: true, reloadOnChange: true);
            #endif

            var MyPolicyCorce = "MyPolicyCorce";



            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyPolicyCorce, policy =>
                {
                    policy
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });



            builder.Services.AddControllers()
           .ConfigureApiBehaviorOptions(options =>
           {
               // options.SuppressMapClientErrors = true; //���������� ������ ProblemDetails
           });



            string connectionString = builder.Configuration.GetConnectionString(nameof(AppDbContext)) ?? throw new ArgumentNullException("Connection string is null");


            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

             
         //   app.UseStaticFiles();
            app.UseRouting();


            app.UseCors(MyPolicyCorce);
          //  app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}"

           );

            app.MapControllers();

            app.Run();
        }
    }
}
