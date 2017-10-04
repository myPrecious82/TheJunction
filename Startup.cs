using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using TheJunction.Data;
using TheJunction.Models;
using TheJunction.Repositories;
using TheJunction.Services;
using TheJunction.ViewModels;

namespace TheJunction
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            if (_env.IsEnvironment("Development") || _env.IsEnvironment("Testing"))
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                // implement a real Mail Service
            }

            services.AddDbContext<MyContext>();

            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();

            //services.AddScoped<IScheduleRepository, MockScheduleRepository>();

            services.AddTransient<MyContextSeedData>();

            services.AddLogging();

            services.AddMvc()
                .AddJsonOptions(config =>
                {
                    config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            MyContextSeedData seeder,
            ILoggerFactory factory)
        {

            Mapper.Initialize(config =>
            {
                config.CreateMap<DailySheetViewModel, DailySheet>().ReverseMap();
                config.CreateMap<EmployeeHandbookAcceptanceViewModel, EmployeeHandbookAcceptance>().ReverseMap();
                config.CreateMap<EmployeeHandbookViewModel, EmployeeHandbook>().ReverseMap();
                config.CreateMap<EmployeeViewModel, Employee>().ReverseMap();
                config.CreateMap<InventoryViewModel, Inventory>().ReverseMap();
                config.CreateMap<PumpPriceTankViewModel, PumpPriceTank>().ReverseMap();
                config.CreateMap<PumpPriceViewModel, PumpPrice>().ReverseMap();
                config.CreateMap<ScheduleViewModel, Schedule>().ReverseMap();
                config.CreateMap<ShiftTradeRequestViewModel, ShiftTradeRequest>().ReverseMap();
                config.CreateMap<ShiftViewModel, Shift>().ReverseMap();
                config.CreateMap<TimeOffRequestViewModel, TimeOffRequest>().ReverseMap();
                config.CreateMap<TimeSheetViewModel, TimeSheet>().ReverseMap();
            });
            if (_env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
                //factory.AddDebug(LogLevel.Information);
            } else
            {
                factory.AddConsole(LogLevel.Error);
            }

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}
