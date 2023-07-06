using NIP_backend.Config;
using NIP_backend.DbContext;
using NIP_backend.Mapping;

namespace NIP_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var corsConfig = builder.Configuration.GetSection("Cors").Get<CorsConfig>();
            builder.Services.AddSingleton(corsConfig);

            builder.Services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(corsConfig.AllowedOrigins.ToArray());
                });
            });

            builder.Services.AddSingleton(builder.Configuration.GetSection("TaxApi").Get<TaxApiConfig>());

            builder.Services.AddDbContext<NipDatabaseContext>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}