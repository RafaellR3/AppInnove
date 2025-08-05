using Microsoft.EntityFrameworkCore;
using Repositorio.Infra;

namespace Repositorio
{
    public class ContextoBanco: Contexto
    {
        public ContextoBanco(DbContextOptions<Contexto> contexto)
           : base(contexto)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        #region ModelCreating
        public override void ModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoBanco).Assembly);
            modelBuilder.Ignore<Dictionary<string, object>>();
        }
        #endregion

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
