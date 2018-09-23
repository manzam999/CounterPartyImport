using CounterPartyImport.Data;
using CounterPartyImport.Entities;
using CounterPartyImport.Interfaces;
using CounterPartyImport.Repositories;
using CounterPartyImport.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace CounterPartyImport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddCors(o => o.AddPolicy("CounterPartyImportPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddTransient<IRepositoryBase<Company>, RepositoryBase<Company>>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddDbContext<CounterPartyImportDbContext>(d => d.UseSqlServer(config.GetConnectionString("CounterPartyImportDatabase")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("CounterPartyImportPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
