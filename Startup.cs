using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnotechExam.Modules;
using InnotechExam.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InnotechExam
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
            services.AddCors(policy => {
                policy.AddPolicy("corspolicy", rules => {
                    rules.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
                });
            });
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddControllers();
            services.AddSingleton<ITaskModule, TaskModule>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("corspolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUI();
            app.UseSwagger(x => x.SerializeAsV2 = true);
        }
    }
}
