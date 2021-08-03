using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Business.Interfaces
{
    public interface IFornecedorService
    {
        void Adicionar(Fornecedor fornecedor);
        void Atualizar(Fornecedor fornecedor);

        void Excluir(Guid Id);

        IEnumerable<Fornecedor> Listar();

        Fornecedor SelecionarPorId(Guid idFornecedor);
    }
}
