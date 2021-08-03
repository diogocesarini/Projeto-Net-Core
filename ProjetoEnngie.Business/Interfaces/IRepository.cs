using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoEnngie.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(Guid id);
        List<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        void SaveChanges();
    }
}