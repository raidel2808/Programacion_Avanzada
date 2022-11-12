using Lab1_1;
using repository;

namespace WebApi
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

            // Add repository as service
            var connectionString = new ConnectionString(@"Data Source=LAPTOP-DOFK9MS3\SQLDEVELPMENT;AttachDBFilename=D:\Cujae\3er año\2do Semestre\Programación Avnazada\Código\HumanResourcesDB.mdf;Initial Catalog=HumanResourcesDB;User ID=sa;Password=12345678");
            builder.Services.AddSingleton(connectionString);
            builder.Services.AddScoped<IPImportedRepository, DBRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.MapControllers();

            app.Run();
        }
    }
}