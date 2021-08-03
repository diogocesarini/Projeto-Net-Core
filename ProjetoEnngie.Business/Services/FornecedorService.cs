using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Business.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;


        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;

        }

        public void Adicionar(Fornecedor fornecedor)
        {
            _fornecedorRepository.Adicionar(fornecedor);

        }

        public IEnumerable<Fornecedor> Listar()
        {
            var fornecedores = _fornecedorRepository.ObterTodos();

            return fornecedores;
        }


        public Fornecedor SelecionarPorId(Guid idFornecedor)
        {
            var entity = _fornecedorRepository.ObterPorId(idFornecedor);
            return entity;
        }

        public void Atualizar(Fornecedor fornecedor)
        {
            if (fornecedor.Id != null || fornecedor.Id != Guid.NewGuid())
            {
                _fornecedorRepository.Atualizar(fornecedor);
            }

        }


        public void Excluir(Guid Id)
        {
            if (Id != null)
            {
                _fornecedorRepository.Remover(Id);
            }

        }

    }
}
