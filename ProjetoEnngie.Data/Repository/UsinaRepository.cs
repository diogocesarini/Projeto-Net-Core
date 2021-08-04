using Microsoft.EntityFrameworkCore;
using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEnngie.Data.Repository
{
    public class UsinaRepository : Repository<Usina>, IUsinaRepository
    {
        public UsinaRepository(MeuDBContext context) : base(context)
        {


        }

        public Usina SelecionarPorUsinaId(Guid id)
        {
            return Db.Set<Usina>()
                .Include(x => x.Fornecedor)
                .FirstOrDefault(x => x.Id == id);
        }

        public Usina SelecionarNome(string Nome, Guid id)
        {
            return Db.Set<Usina>()
                .Include(x => x.Fornecedor)
                .FirstOrDefault(x => x.Fornecedor.Id == id && x.Nome == Nome);
        }

        public IEnumerable<Usina> ListaUsinas()
        {
            return Db.Set<Usina>()
                .Include(x => x.Fornecedor)
                .Where(x => x.Ativo);
        }

        public IEnumerable<Usina> ListaUsinasFiltro(Guid idFornecedor, bool Ativo)
        {
           
            if (idFornecedor != null)
            {
                return Db.Set<Usina>()
                    .Include(x => x.Fornecedor)
                    .Where(x => x.Ativo == Ativo && x.Fornecedor.Id == idFornecedor);
            }

            else
            {
                return Db.Set<Usina>()
                .Include(x => x.Fornecedor)
                .Where(x => x.Ativo == Ativo);
            }

        }

    }
}
