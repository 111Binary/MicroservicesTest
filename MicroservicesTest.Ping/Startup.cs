using MicroservicesTest.Common.Commands;
using MicroservicesTest.Common.Mongo;
using MicroservicesTest.Common.RabbitMq;
using MicroservicesTest.Ping.Domain.Repositories;
using MicroservicesTest.Ping.Repositories;
using MicroservicesTest.Ping.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroservicesTest.Ping.Handlers;

namespace MicroservicesTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddLogging();
            services.AddMongoDB(Configuration);
            services.AddScoped<IPingRepository, PingRepository>();
            services.AddRabbitMq(Configuration);
            services.AddScoped<IPingBusinessService, PingBusinessService>();
            services.AddScoped<ICommandHandler<PingCommand>, PingCommandHandler>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
