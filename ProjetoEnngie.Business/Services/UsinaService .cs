using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Business.Services
{
    public class UsinaService : IUsinaService
    {
        private readonly IUsinaRepository _UsinaRepository;


        public UsinaService(IUsinaRepository UsinaRepository)
        {
            _UsinaRepository = UsinaRepository;

        }

        public void Adicionar(Usina Usina)
        {
            _UsinaRepository.Adicionar(Usina);

        }

        public IEnumerable<Usina> Listar()
        {
            var Usinaes = _UsinaRepository.ObterTodos();

            return Usinaes;
        }


        public Usina SelecionarPorId(Guid idUsina)
        {
            var entity = _UsinaRepository.ObterPorId(idUsina);
            return entity;
        }

        public void Atualizar(Usina Usina)
        {
            if (Usina.Id != null || Usina.Id != Guid.NewGuid())
            {
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
