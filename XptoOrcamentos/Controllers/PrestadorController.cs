using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XptoOrcamentos.Models.Prestador;
using XptoOrcamentos.Util;

namespace XptoOrcamentos.Controllers
{
    public class PrestadorController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IPrestadorService _prestadorService;
        private readonly IEmpresaService _empresaService;
        private readonly ILogServiceRepository _log;

        public PrestadorController(INotyfService notyf, IPrestadorService prestador,
                                   IEmpresaService empresaService, ILogServiceRepository log)
        {
            _notyf = notyf;
            _log = log;
            _empresaService = empresaService;
            _prestadorService = prestador;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var dados = await _prestadorService.Buscar();
                PrestadorViewModel model = new PrestadorViewModel();

                if (dados != null && dados.Count() > 0)
                {
                    model.Prestadores = dados.Select(c => new Prestadores
                    {
                        Id = c.Id,
                        CPF = c.CPF.FormataCPF(),
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
        public async Task<ActionResult> Create()
        {
            try
            {
                PrestadorViewModelNew viewModel = new PrestadorViewModelNew
                {
                    Empresas = await BuscarEmpresas()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PrestadorViewModelNew viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);

                await _prestadorService.Inserir(new Prestador
                {
                    IdEmpresa = viewModel.IdEmpresa,
                    CPF = viewModel.CPF,
                    Nome = viewModel.Nome
                });

                _notyf.Success("O Prestador foi cadastrado com sucesso");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        private async Task<List<SelectListItem>> BuscarEmpresas()
        {
            var dados = await _empresaService.Buscar();

            return dados.ToList().Select(c => new SelectListItem()
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            }).ToList();
        }
    }
}
