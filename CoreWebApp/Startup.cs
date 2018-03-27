using CoreWebApp.Filters;
using LibraryData;
using LibraryData.Data.IRepositories;
using LibraryData.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoreWebApp
{
    public class Startup
    {
        private ILoggerFactory LoggerFactory;
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            LoggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Adicionando o serviço
            services.AddScoped<IFriendRepository, FriendRepository>();

            string connectionStringLibrary = Configuration.GetSection("Database").GetSection("CoreWebApp")["LibraryConnection"];
            services.AddDbContext<LibraryContext>(options
                => options.EnableSensitiveDataLogging()
                .UseLoggerFactory(LoggerFactory)
                .UseSqlServer(connectionStringLibrary));

            services.AddSingleton(Configuration);

            // Enable in-memory cache
            services.AddMemoryCache();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelCheckFilter));
            }).AddJsonOptions(options =>
            {
                // Supress null values from JSON
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }

        
    }
}
