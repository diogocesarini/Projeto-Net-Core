using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Business.Services
{
    public class UsinaService : IUsinaService
    {
        private readonly IUsinaRepository _UsinaRepository;
        private readonly IFornecedorRepository _fornecedorRepository;

        public UsinaService(IUsinaRepository UsinaRepository, IFornecedorRepository fornecedorRepository)
        {
            _UsinaRepository = UsinaRepository;
            _fornecedorRepository = fornecedorRepository;

        }

        public void Adicionar(Usina Usina)
        {
            try
            {
                var fornecedor = _fornecedorRepository.ObterPorId(Usina.Fornecedor.Id);

                var usina = _UsinaRepository.SelecionarNome(Usina.Nome, Usina.Fornecedor.Id);

                if (usina == null)
                {
                    Usina.Fornecedor = fornecedor;

                    _UsinaRepository.Adicionar(Usina);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usina> Listar()
        {
            var Usinas = _UsinaRepository.ObterTodos();

            return Usinas;
        }


        public Usina SelecionarPorId(Guid idUsina)
        {
            var entity = _UsinaRepository.SelecionarPorUsinaId(idUsina);

            return entity;
        }

        public IEnumerable<Usina> ListaUsinas()
        {
            var entity = _UsinaRepository.ListaUsinas();

            return entity;
        }

        public IEnumerable<Usina> ListaUsinasFiltro(Guid? idFornecedor , bool Ativo)
        {
            var entity = _UsinaRepository.ListaUsinasFiltro((Guid)idFornecedor, Ativo);

            return entity;
        }

        public void Atualizar(Usina Usina)
        {
            if (Usina.Id != null || Usina.Id != Guid.NewGuid())
            {
                var fornecedor = _fornecedorRepository.ObterPorId(Usina.Fornecedor.Id);
                Usina.Fornecedor = fornecedor;

                _UsinaRepository.Atualizar(Usina);
            }

        }

        public void Excluir(Guid Id)
        {
            if (Id != null)
            {
                _UsinaRepository.Remover(Id);
            }

        }

    }
}
