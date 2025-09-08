




namespace Bookiee.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddPresentationServices();

            builder.Services.AddCoreServices(builder.Configuration);

            builder.Services.AddInfrastructureServices(builder.Configuration);


            
            var app = builder.Build();
            await InitializeDbContext(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();
           

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


            async Task InitializeDbContext(WebApplication app)
            {
                using var scope = app.Services.CreateScope(); // resolve dependinceies
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                await dbInitializer.InitializeIdentityAsync();
                await dbInitializer.InitializeAppAsync();
               
            }
        }
    }
}
