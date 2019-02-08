using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APICore.Helpers;
using ConcreteCore;
using Microsoft.Extensions.FileProviders;
using ConcreteCore.CRM.Lead;
using ConcreteCore.FA.BK;
using ConcreteCore.FA.BK.Master;
using ConcreteCore.Misc;
using ConcreteCore.Security.Admin.Regional;
using System.IO;
using ConcreteCore.Security.User;
using ConcreteCore.HRMS.Admin.Test;
using InterfaceCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelCore.HRMS.Admin.Recruitment;
using Newtonsoft.Json;
using ConcreteCore.HRMS.Admin.Recruitment;

namespace APICore
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);  // system generated line
            // Register services
            services.AddTransient<IMenu, MenuConcrete>();
            services.AddTransient<IUser, UserConcrete>();
            services.AddTransient<ICountry, CountryConcrete>();
            services.AddTransient<IState, StateConcrete>();
            services.AddTransient<ICity, CityConcrete>();
            services.AddTransient<ICRMLead, CRMLeadConcrete>();
            services.AddTransient<ILedger, LedgerConcrete>();
            services.AddTransient<ICommon, CommonConcrete>();
            services.AddTransient<IPageEvents, PageEventsConcrete>();
            services.AddTransient<IBank, BankConcrete>();
            services.AddTransient<ICurrency, CurrencyConcrete>();
            services.AddTransient<ITRIALSp, TRIALSpConcrete>();
            services.AddTransient<IHRMSRolesResponsibility, HRMSRolesResponsibilityConcrete>();



            // End of Register services
            //services.AddMvc();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddCors();
            // Getting connection string from database
            var Databaseconnection = Configuration.GetConnectionString("DatabaseConnection");
            // UseRowNumberForPaging for using skip and take in .Net core
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Databaseconnection, b => b.UseRowNumberForPaging()));
            services.AddDbContext<AMTDEVContext>(options => options.UseSqlServer(Databaseconnection, b => b.UseRowNumberForPaging()));
            // Token Part
            var mKey = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(mKey),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            // End of Token Part
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //  app.UseHsts();
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            
           
            app.UseMvc();
        }
    }
}
