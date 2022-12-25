using Messenger.AppService.Classes;
using Messenger.WebApiCore.Classes;
using Messenger.WebApiCore.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using System.Configuration;
using System.Data.SqlClient;

[assembly: OwinStartupAttribute(typeof(Messenger.WebApiCore.Startup))]
namespace Messenger.WebApiCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public static string _connection;
       
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            _connection = AesEncryptionAlgorithm.DecryptConnection(Configuration["AppSettings:StorageConnectionString"]);
            
        }

        public static IHubContext<Message> _context;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));
            
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:51675/").AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddSignalR();
            services.AddSignalRCore();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHubContext<Message> context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////app.Run(async (context) =>
            ////{
            ////    await context.Response.WriteAsync("Hello World!");
            ////});
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
            _context = context;
            app.UseSignalR(reuters =>
                {
                    reuters.MapHub<Message>("/message");
                }
            );

           
            MessageDB.ProgramDepency();
        }
    }
}
