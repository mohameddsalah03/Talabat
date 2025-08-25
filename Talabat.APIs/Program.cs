using Talabat.APIs.Extensions;
using Talabat.APIs.Services;
using Talabat.Core.Application.Abstraction;
using Talabat.Infrastructure.Persistence;
using Talabat.Core.Application;

 
namespace Talabat.APIs
{
    public class Program
    {
        //Entry Point
        public static async Task Main(string[] args)
        {

            var WebApplicationbuilder = WebApplication.CreateBuilder(args);


            #region Configure Services [Container For DI]

            // Add services to the container.

            WebApplicationbuilder.Services
                .AddControllers()
                .AddApplicationPart(typeof(Controllers.AssemblyInformation).Assembly); //Register Reqiured Services By ASP.NET Core Web APIs To DI Container 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            //Reauired Services For Swagger
            WebApplicationbuilder.Services.AddEndpointsApiExplorer();
            WebApplicationbuilder.Services.AddSwaggerGen();

            // Persistence Services Layer 
            WebApplicationbuilder.Services.AddPersistenceServices(WebApplicationbuilder.Configuration);


            //
            WebApplicationbuilder.Services.AddHttpContextAccessor();
            WebApplicationbuilder.Services.AddScoped(typeof(ILoggedInUserService) , typeof(LoggedInUserService));


            //
            WebApplicationbuilder.Services.AddApplicationServices();

            #endregion


            var app = WebApplicationbuilder.Build();

            #region Database Initializer 

            await app.InitializeStoreContext();

            #endregion

            #region Configure Kestral Middlewares (Pipelines)

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // for wwwroot Path
            app.UseStaticFiles();

            app.MapControllers();

            #endregion
            
            
            app.Run();


        }
    }
}
