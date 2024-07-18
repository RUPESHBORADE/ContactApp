using ContactApp.Services;
using Newtonsoft.Json;

namespace ContactApp.Infrastructure
{
    public class Startup : IStartup
    {
        private readonly IWebHostEnvironment _env;

        // Constructor to inject the hosting environment
        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        // Configure method to set up the HTTP request pipeline
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Global exception handler middleware
            app.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke();
                }
                catch (Exception ex)
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 500;
                    var errorResponse = new { Message = "An error occurred while processing your request." };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
                }
            });
        }

        // ConfigureServices method to register services
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddSingleton<ContactService>();

            // Build and return the service provider
            return services.BuildServiceProvider();
        }
    }
}
