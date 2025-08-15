using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Infra
{
    public interface IRepBase<TEntidade> : IDisposable where TEntidade : IdentificadorGuid
    {
        public void Dispose();
        TEntidade Find(int id);
        IQueryable<TEntidade> Recuperar(params string[] includes);
        IQueryable<TEntidade> Where(Expression<Func<TEntidade, bool>> exp);
        TEntidade Single();
        TEntidade Single(Expression<Func<TEntidade, bool>> exp);
        TEntidade SingleOrDefault();
        TEntidade SingleOrDefault(Expression<Func<TEntidade, bool>> exp);
        TEntidade First();
        TEntidade First(Expression<Func<TEntidade, bool>> exp);
        TEntidade FirstOrDefault();
        TEntidade FirstOrDefault(Expression<Func<TEntidade, bool>> exp);
        IQueryable<TCampos> Select<TCampos>(Expression<Func<TEntidade, TCampos>> campos);
        IOrderedQueryable<TEntidade> OrderBy<TCampos>(Expression<Func<TEntidade, TCampos>> campos);
        IOrderedQueryable<TEntidade> OrderByDescending<TCampos>(Expression<Func<TEntidade, TCampos>> campos);
        bool Any();
        bool Any(Expression<Func<TEntidade, bool>> exp);
        void InserirPersistido(TEntidade obj);
        void Inserir(List<TEntidade> objs);
        void Persistir();
        void RejectChanges();
    }
}
