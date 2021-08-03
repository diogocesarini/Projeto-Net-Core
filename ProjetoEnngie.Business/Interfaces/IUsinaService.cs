using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Business.Interfaces
{
    public interface IUsinaService
    {
        void Adicionar(Usina Usina);
        void Atualizar(Usina Usina);

        void Excluir(Guid Id);

        IEnumerable<Usina> Listar();

        Usina SelecionarPorId(Guid idUsina);
    }
}
