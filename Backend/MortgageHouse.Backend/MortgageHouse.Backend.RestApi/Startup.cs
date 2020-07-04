using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MortgageHouse.Backend.Constants;
using MortgageHouse.Backend.CsvDriver.Repositories;
using MortgageHouse.Backend.CsvDriver.Services;
using MortgageHouse.Backend.Domain.Entities;
using MortgageHouse.Backend.Domain.ServiceArtifacts;
using MortgageHouse.Backend.RestApi.Mapper;
using MortgageHouse.Backend.RestApi.Middleware;
using MortgageHouse.Backend.Services.Business;
using MortgageHouse.Backend.Services.Security;

namespace MortgageHouse.Backend.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(w => w.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            //Services
            services.AddScoped<AddressService>()
                .AddScoped<ContactsService>();

            //Repositories
            services.AddScoped<DatabaseService>() //Configure the DbContext used for reading and writing to the csv file
           .AddScoped<IAddressRepository, AddressRepository>()
       .AddScoped<IContactsRepository, ContactsRepository>();

            //Mapper
            AutoMapper.MapperConfiguration appConfig = new MapperConfiguration(c => c.AddProfile<GatewayMapper>());
            services.AddScoped<IMapper>(c => appConfig.CreateMapper());

            //Service required for the basic auth middelware to work
            services.AddScoped<IUserSecurity, UserSecurity>();

            //Gzip Compression
            services.Configure<BrotliCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            //Services for Authentication
            services.AddAuthentication(SecurityConstants.AuthenticationScheme)
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(SecurityConstants.AuthenticationScheme, null);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()  //Allows the client to hardcode keys into the headers for Basic Auth
                );

            app.UseAuthentication(); //Enable IIS Authentication
            app.UseResponseCompression(); //Response Compression middleware for faster response times
            app.UseMvc();
        }
    }
}
