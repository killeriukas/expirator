using System;
using AutoMapper;
using Expirator.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Expirator {
    public class Startup {

		public IConfiguration Configuration { get; }

		private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder => {
									  builder.WithOrigins("https://localhost",
														  "http://localhost").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
								  });
			});

			services.AddControllers().AddNewtonsoftJson(s => {
				s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});
			
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			//services.AddScoped<IExpiratorRepo, MockExpiratorRepo>();
			services.AddSingleton<IExpiratorRepo, MockExpiratorRepo>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

			if(env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();


			app.UseCors(MyAllowSpecificOrigins);

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
