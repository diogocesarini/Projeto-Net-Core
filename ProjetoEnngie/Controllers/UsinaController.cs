using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoEnngie.Business.Interfaces;
using ProjetoEnngie.Business.Models;
using ProjetoEnngie.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEnngie.Controllers
{
    public class UsinaController : Controller
    {
        private readonly IUsinaService _UsinaService;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;


        public UsinaController(IUsinaService UsinaService, IMapper mapper, IFornecedorService fornecedorService)
        {
            _UsinaService = UsinaService;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }
        public IActionResult Index()
        {
            var lista = _UsinaService.Listar();

            var novaLista = new List<UsinaVM>();

            foreach (var x in lista)
            {
                novaLista.Add(new UsinaVM()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Ativo = x.Ativo
                });
            }

            return View(novaLista);
        }

        public ActionResult Create()
        {
            var vm = new UsinaVM();

            var Lista = _fornecedorService.Listar();

            vm.Fornecedores = _mapper.Map<List<FornecedorVM>>(Lista);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(UsinaVM vm)
        {
            var resp = new BaseResponse();
            try
            {
                _UsinaService.Adicionar(_mapper.Map<Usina>(vm));
                resp.Valor = vm.Id;
            }
            catch (Exception ex)
            {
                resp.Sucesso = false;
                resp.Erro = ex.Message;
            }

            return Json(resp);

        }


        public ActionResult Edit(Guid id)
        {
            var Usina = _UsinaService.SelecionarPorId(id);

            var vm = new UsinaVM();

            vm = _mapper.Map<UsinaVM>(Usina);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(UsinaVM vm)
        {

            var resp = new BaseResponse();
            try
            {
                if (vm.Id != null)
                {
                    _UsinaService.Atualizar(_mapper.Map<Usina>(vm));
                    resp.Valor = vm.Id;
                }

            }
            catch (Exception ex)
            {

                resp.Sucesso = false;
                resp.Erro = ex.Message;
            }

            return Json(resp);

        }

        public ActionResult Delete(Guid id)
        {
            var resp = new BaseResponse();
            try
            {
                _UsinaService.Excluir(id);
            }
            catch (Exception ex)
            {
                resp.Sucesso = false;
                resp.Erro = ex.Message;
            }
            return Json(resp);
        }

    }
}
