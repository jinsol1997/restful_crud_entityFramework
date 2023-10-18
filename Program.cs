using Microsoft.EntityFrameworkCore;
using restful_crud_asp.Services;
using restful_crud_asp.Data;


public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices((hostContext, services) =>
                {
                    // 데이터베이스 연결 및 Entity Framework 구성
                    services.AddDbContext<LanguageContext>(options =>
                    {
                        var connection = hostContext.Configuration.GetConnectionString("DefaultConnection");
                        options.UseMySql(connection, ServerVersion.AutoDetect(connection));
                    });

                    // 서비스 등록
                    services.AddScoped<LanguageService>();

                    services.AddControllers();
                });

                webBuilder.Configure((hostContext, app) =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
}