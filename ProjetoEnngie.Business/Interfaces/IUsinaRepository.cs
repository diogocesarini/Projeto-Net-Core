using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Business.Interfaces
{
    public interface IUsinaRepository : IRepository<Usina>
    {
        public Usina SelecionarPorUsinaId(Guid id);

        public IEnumerable<Usina> ListaUsinas();

        public IEnumerable<Usina> ListaUsinasFiltro(Guid IdFornecedor, bool Ativo);

        public Usina SelecionarNome(string Nome, Guid id);
    }
}
