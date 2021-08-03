using Microsoft.EntityFrameworkCore;
using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProjetoEnngie.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDBContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDBContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            Db.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            Db.SaveChanges();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            Db.SaveChanges();
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}