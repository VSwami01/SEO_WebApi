using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SEO_WebApi.Helpers;
using SEO_WebApi.Middleware;
using SEO_WebApi.Services;

namespace SEO_WebApi
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
            services.AddControllers(); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SEO_WebApi", Version = "v1" });
                //c.AddSecurityDefinition("[auth scheme: same name as defined for asp.net]", new OpenApiSecurityScheme()
                //{
                //    In = ParameterLocation.Header,
                //    Name = "ApiKey", //header with api key
                //    Type = SecuritySchemeType.ApiKey,
                //});
            });

            services.AddScoped<IGoogleSearch, GoogleSearch>();
            services.AddScoped<IWebScrapper, WebScrapper>();
            services.AddScoped<IRegexHelper, RegexHelper>();
            services.AddScoped<IHtmlHelper, HtmlHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SEO_WebApi v1"));
            }
            //app.UseMiddleware<ApiKeyMiddleware>();

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
