using Microsoft.EntityFrameworkCore;

namespace Repositorio.Infra
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public virtual void ModelCreating(ModelBuilder modelBuilder)
        {
        }
     
    }
}
