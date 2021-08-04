using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var lista = _UsinaService.ListaUsinas().ToList();
            var vm = new UsinaVM();
            var novaLista = new List<UsinaVM>();

            vm.Fornecedores = MontarComboFornecedores();

            foreach (var x in lista)
            {
                novaLista.Add(new UsinaVM()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    NomeFornecedor = x.Fornecedor.Nome,
                    Ativo = x.Ativo
                });
            }
            vm.Usinas = novaLista;


            return View(vm);
        }

        [HttpPost]
        public ActionResult Filtro(UsinaVM vm)
        {
            vm.Usinas = MontarListaUsinas(vm);
            vm.Fornecedores = MontarComboFornecedores();

            return View("Index", vm);
        }

        public ActionResult Create()
        {
            var vm = new UsinaVM();

            vm.Fornecedores = MontarComboFornecedores();

            return View(vm);
        }

        protected IEnumerable<SelectListItem> MontarComboFornecedores()
        {
            return _fornecedorService.Listar().Select(x => new SelectListItem
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            });
        }

        protected IEnumerable<SelectListItem> MontarComboUsinas()
        {
            return _UsinaService.Listar().Select(x => new SelectListItem
            {
                Text = x.Nome,
                Value = x.Id.ToString()
            });
        }

        protected List<UsinaVM> MontarListaUsinas(UsinaVM vM)
        {
            var novaLista = new List<UsinaVM>();
            if (vM.FornecedorId != null && vM.Ativo || !vM.Ativo)
            {
                var lista = _UsinaService.ListaUsinasFiltro(vM.FornecedorId, vM.Ativo).ToList();

                foreach (var x in lista)
                {
                    novaLista.Add(new UsinaVM()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        NomeFornecedor = x.Fornecedor.Nome,
                        Ativo = x.Ativo
                    });
                }

            }
            
            if(novaLista.Count == 0)
            {
                var lista = _UsinaService.ListaUsinas().ToList();
                foreach (var x in lista)
                {
                    novaLista.Add(new UsinaVM()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        NomeFornecedor = x.Fornecedor.Nome,
                        Ativo = x.Ativo
                    });
                }

            }
            return novaLista;
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

            return RedirectToAction("Index", "Usina");

        }

        public ActionResult Edit(Guid id)
        {
            var Usina = _UsinaService.SelecionarPorId(id);

            var vm = _mapper.Map<UsinaVM>(Usina);

            vm.Fornecedores = MontarComboFornecedores();

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

            return RedirectToAction("Index", "Usina");

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
            return RedirectToAction("Index", "Usina");
        }

    }
}
