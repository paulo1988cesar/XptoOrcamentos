using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using XptoOrcamentos.Models.Empresa;
using XptoOrcamentos.Util;

namespace XptoOrcamentos.Controllers
{

    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;
        private readonly INotyfService _notyf;
        private readonly ILogServiceRepository _log;

        public EmpresaController(IEmpresaService empresaService, INotyfService notyf,
                                 ILogServiceRepository log)
        {
            _empresaService = empresaService;
            _log = log;
            _notyf = notyf;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            try
            {
                var dados = await _empresaService.Buscar();
                EmpreaViewModel model = new EmpreaViewModel();

                if (dados != null && dados.Count() > 0)
                {
                    model.Empresas = dados.Select(c => new Empresas
                    {
                        Id = c.Id,
                        CNPJ = c.CNPJ.FormataCNPJ(),
                        Nome = c.Nome
                    }).ToList();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            EmpreaViewModelNew viewModel = new EmpreaViewModelNew();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmpreaViewModelNew viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);

                await _empresaService.Inserir(new Empresa
                {
                    CNPJ = viewModel.CNPJ,
                    Nome = viewModel.Nome
                });

                _notyf.Success("A Empresa foi cadastrada com sucesso");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
