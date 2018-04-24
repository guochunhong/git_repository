﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet5FileUploadFileTable.Controllers;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNet5FileUploadFileTable
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));

            var sqlConnectionString = Configuration["ApplicationConfiguration:SQLConnectionString"];

            services.AddDbContext<FileContext>(options =>
                options.UseSqlServer(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("AspNetCoreFileUploadFileTable")
                )
            );

            services.AddMvc();

            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<ValidateMimeMultipartContentFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FileClient}/{action=ViewAllFiles}/{id?}");
            });
        }
    }
}
