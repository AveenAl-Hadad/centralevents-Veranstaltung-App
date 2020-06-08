namespace CentralEvents.Web.App
{
	using System.Text;

	using CentralEvents.Web.App.ServiceComponents;
	using CentralEvents.Web.App.Wrappers;

	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using Microsoft.IdentityModel.Tokens;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddScoped<IHttpClient, HttpClientWrapper>();

			//JWT
			services.AddScoped<IServiceComponent, ServiceComponent>();
			//services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			//		.AddJwtBearer(option =>
			//					  {
			//						  option.TokenValidationParameters = new TokenValidationParameters
			//															 {
			//																 ValidateIssuer = true,
			//																 ValidateAudience = true,
			//																 ValidateLifetime = true,
			//																 ValidateIssuerSigningKey = true,
			//																 ValidIssuer = this.Configuration["Jwt: Issuer"],
			//																 ValidAudience = this.Configuration["Jwt:Issuer"],
			//																 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Jwt:Key"]))
			//															 };

			//						  // .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options));
			//						  //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));
			//					  });
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// JWT
			//app.UseAuthentication();
			//app.UseAuthorization();

			app.UseEndpoints(endpoints =>
							 {
								 endpoints.MapBlazorHub();
								 //endpoints.MapRazorPages();
								 //endpoints.MapDefaultControllerRoute(); // JWT
								 endpoints.MapFallbackToPage("/_Host");
							 });
		}
	}
}