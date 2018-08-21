using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReflectionIT.Mvc.Paging;
using Swashbuckle.AspNetCore.Swagger;
using testdbfirst.Repository.ImplRepository;

namespace testdbfirst
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
            
            services.AddTransient<IRefProductCategories, RefProductCategoriesImpl>();
            services.AddTransient<IProduct, ProductImpl>();
            services.AddTransient<ICustomerOrders, CustomerOrdersImpl>();
            services.AddTransient<ICustomer, CustomerImpl>();
            services.AddCors(options =>
            {
                // BEGIN01
                options.AddPolicy("AllowSpecificOrigins",
                builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
               


            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Core API", Description = "Swagger Core API" });

            }
        );


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

            app.UseHttpsRedirection();
             app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
           
            app.UseMvc();
            app.UseSwagger();
            app.UseCors("AllowSpecificOrigins");
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
            });

        }
    }
}
