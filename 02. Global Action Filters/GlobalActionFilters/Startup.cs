using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalActionFilters.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalActionFilters
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
			services.Configure<CookiePolicyOptions>(options => {
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddMvc(options => {
				options.Filters.Add<HandleAndLogErrorAttribute>();
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment()) {
				// https://github.com/aspnet/AspNetCore/blob/28157e62597bf0e043bc7e937e44c5ec81946b83/src/Middleware/Diagnostics/src/DeveloperExceptionPage/DeveloperExceptionPageExtensions.cs
				// https://github.com/aspnet/AspNetCore/blob/4e44025a52e4b73aa17e09a8041b0e166e0c5ce0/src/Middleware/Diagnostics/src/DeveloperExceptionPage/DeveloperExceptionPageMiddleware.cs
				app.UseDeveloperExceptionPage();
			} else {
				// https://github.com/aspnet/AspNetCore/blob/28157e62597bf0e043bc7e937e44c5ec81946b83/src/Middleware/Diagnostics/src/ExceptionHandler/ExceptionHandlerExtensions.cs
				// https://github.com/aspnet/AspNetCore/blob/28157e62597bf0e043bc7e937e44c5ec81946b83/src/Middleware/Diagnostics/src/ExceptionHandler/ExceptionHandlerMiddleware.cs
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvcWithDefaultRoute();
		}
	}
}
