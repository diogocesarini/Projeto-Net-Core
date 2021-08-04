using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Models;
using System;
using System.Collections.Generic;

namespace ProjetoEnngie.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;


        public FornecedoresController(IFornecedorService fornecedorService, IMapper mapper)
        {
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var lista = _fornecedorService.Listar();

            var novaLista = new List<FornecedorVM>();

            foreach (var x in lista)
            {
                novaLista.Add(new FornecedorVM()
                {
                    Id = x.Id,
                    Nome = x.Nome
                });
            }

            return View(novaLista);
        }

        public ActionResult Create()
        {
            var vm = new FornecedorVM();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(FornecedorVM vm)
        {
            var resp = new BaseResponse();
            try
            {
                _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(vm));
                resp.Valor = vm.Id;
            }
            catch (Exception ex)
            {
                resp.Sucesso = false;
                resp.Erro = ex.Message;
            }

            return RedirectToAction("Index", "Fornecedores");

        }


        public ActionResult Edit(Guid id)
        {
            var fornecedor = _fornecedorService.SelecionarPorId(id);

            var vm = new FornecedorVM();

            vm = _mapper.Map<FornecedorVM>(fornecedor);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(FornecedorVM vm)
        {

            var resp = new BaseResponse();
            try
            {
                if (vm.Id != null)
                {
                    _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(vm));
                    resp.Valor = vm.Id;
                }

            }
            catch (Exception ex)
            {

                resp.Sucesso = false;
                resp.Erro = ex.Message;
            }

            return RedirectToAction("Edit", "Fornecedores");

        }

        public ActionResult Delete(Guid id)
        {
            var resp = new BaseResponse();
            try
            {
                _fornecedorService.Excluir(id);
            }
            catch (Exception ex)
            {
                resp.Sucesso = false;
                resp.Erro = ex.Message;
            }
            return RedirectToAction("Index", "Fornecedores");
        }

    }
}
