using Microsoft.EntityFrameworkCore;
using Repositorio.Infra;

namespace Api.Extencao
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,  WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;
            var conexao = configuration.GetConnectionString("DefaultConnection");
            services = builder.Services.AddDbContext<Contexto>(options =>
                    options.UseNpgsql(conexao));

            return services;
        }
    }
}
