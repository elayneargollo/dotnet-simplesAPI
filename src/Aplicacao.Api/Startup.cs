using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using System.Reflection;
using System.IO;
using Aplicacao.Business.Interfaces;
using Aplicacao.Business.Services;
using Aplicacao.Data.Repositories;
using Aplicacao.Core.Dto;
using Aplicacao.Core.Models;
using Aplicacao.Api.Models;
using temis.Api.AutoMapper;
using FluentValidation;
using Aplicacao.Business.Validations;
using FluentValidation.AspNetCore;

namespace Aplicacao.Api
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
            var connectionString = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<Contexto>((options) => options.UseMySql(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Aplicacao.api",
                    Version = "v1",
                    Description = "ASP.NET 5.0",

                    Contact = new OpenApiContact
                    {
                        Name = "Aplicação",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/elayneargollo/dotnet-simplesAPI.git"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            });
            IMapper mapper = config.CreateMapper();

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSingleton(mapper);
            services.AddControllers().AddFluentValidation(mvc => mvc.RegisterValidatorsFromAssemblyContaining<Startup>());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aplicacao.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
