using Api.Extencao;
using Aplicacao.Usuarios;
using Dominio.Infra;
using Dominio.Usuarios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using Repositorio.Infra;
using Repositorio.Usuarios;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (!builder.Environment.IsDevelopment() || !IsRunningInDocker())
            {
                builder.WebHost.ConfigureKestrel(serverOptions =>
                {
                    serverOptions.ConfigureHttpsDefaults(httpsOptions =>
                    {
                        // Voc� pode configurar op��es de HTTPS aqui, ou deixar padr�o
                    });
                });
            }

            builder.Services.AddApplicationDbContext(builder);
            builder.Services.AddHttpContextAccessor();


            builder.Services.Scan(scan => scan.FromAssembliesOf(typeof(Usuario), typeof(RepUsuario), typeof(AplicUsuario))
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            builder.Services.AddScoped<Contexto, ContextoBanco>();
            builder.Services.AddScoped(typeof(IRepBase<>), typeof(RepBase<>));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAny",
                    x =>
                    {
                        x.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(_ => true)
                            .AllowCredentials();
                    });
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            if (!IsRunningInDocker())
            {
                app.UseHttpsRedirection();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        private static bool IsRunningInDocker()
        {
            return System.Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";
        }
    }
}