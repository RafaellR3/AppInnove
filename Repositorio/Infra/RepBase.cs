using Dominio.Infra;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositorio.Infra
{
    public class RepBase<TEntidade>: IRepBase<TEntidade>, IDisposable where TEntidade : IdentificadorGuid
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntidade> DbSet;
 
        public RepBase(Contexto contexto)
        {
            Db = contexto;
            DbSet = Db.Set<TEntidade>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntidade Find(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntidade> Recuperar(params string[] includes)
        {
            if (!includes.Any())
            {
                return DbSet;
            }

            IQueryable<TEntidade> queryable = DbSet.AsQueryable();
            foreach (string navigationPropertyPath in includes)
            {
                queryable = queryable.Include(navigationPropertyPath);
            }

            return queryable;
        }

        public IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> exp)
        {
            return DbSet.Where(exp);
        }

        public TEntidade Single()
        {
            return DbSet.Single();
        }

        public TEntidade Single(Expression<Func<TEntidade, bool>> exp)
        {
            return DbSet.Single(exp);
        }

        public TEntidade SingleOrDefault()
        {
            return DbSet.SingleOrDefault();
        }

        public TEntidade SingleOrDefault(Expression<Func<TEntidade, bool>> exp)
        {
            return DbSet.SingleOrDefault(exp);
        }

        public TEntidade First()
        {
            return DbSet.First();
        }

        public TEntidade First(Expression<Func<TEntidade, bool>> exp)
        {
            return DbSet.First(exp);
        }

        public TEntidade FirstOrDefault()
        {
            return DbSet.FirstOrDefault();
        }

        public TEntidade FirstOrDefault(Expression<Func<TEntidade, bool>> exp)
        {
            return DbSet.FirstOrDefault(exp);
        }

        public IQueryable<TCampos> Select<TCampos>(Expression<Func<TEntidade, TCampos>> campos)
        {
            return DbSet.Select(campos);
        }

        public IOrderedQueryable<TEntidade> OrderBy<TCampos>(Expression<Func<TEntidade, TCampos>> campos)
        {
            return DbSet.OrderBy(campos);
        }

        public IOrderedQueryable<TEntidade> OrderByDescending<TCampos>(Expression<Func<TEntidade, TCampos>> campos)
        {
            return DbSet.OrderByDescending(campos);
        }

        public bool Any()
        {
            return DbSet.Any();
        }

        public bool Any(Expression<Func<TEntidade, bool>> exp)
        {
            return DbSet.Any(exp);
        }
    }    
}
