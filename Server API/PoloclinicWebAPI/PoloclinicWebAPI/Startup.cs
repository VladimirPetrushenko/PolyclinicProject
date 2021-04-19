using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PoloclinicWebAPI.Repository.Interfaces;
using PoloclinicWebAPI.Repository.Data;
using PoloclinicWebAPI.Models.DBContext;
using Newtonsoft.Json.Serialization;

namespace PoloclinicWebAPI
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
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Pa55w0rd2021";
            var database = Configuration["Database"] ?? "Policlinic";
            
            
            services.AddDbContext<PoliclinicContext>(opt =>
            {
                //opt.UseSqlServer(Configuration.GetConnectionString("PoliclinicConnection"));
                opt.UseSqlServer($"Server={server},{port};Initial Catalog={database};User Id ={user};Password={password}");
            });

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddScoped<IDoctorRepo, SqlDoctorRepo>();
            services.AddScoped<IDiagnosisRepo, SqlDiagnosisRepo>();
            services.AddScoped<IMedicalCardRepo, SqlMedicalCardRepo>();
            services.AddScoped<IPatientRepo, SqlPatientRepo>();
            services.AddScoped<IQualificationRepo, SqlQualificationRepo>();
            services.AddScoped<ISpecializationRepo, SqlSpecializationRepo>();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PoloclinicWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PoloclinicWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            InitDB.InitPoliclinic(app);

            app.UseCors(builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
