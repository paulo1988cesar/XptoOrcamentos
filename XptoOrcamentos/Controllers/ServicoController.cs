using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using XptoOrcamentos.Models;
using XptoOrcamentos.Models.Servico;
using XptoOrcamentos.Util;

namespace XptoOrcamentos.Controllers
{
    public class ServicoController : Controller
    {

        private readonly IServicoService _service;
        private readonly INotyfService _notyf;
        private readonly ILogServiceRepository _log;

        public ServicoController(IServicoService service, INotyfService notyf,
                                 ILogServiceRepository log)
        {
            _service = service;
            _notyf = notyf;
            _log = log;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                ServicoViewModelList viewModel = new ServicoViewModelList();
                var dados = await _service.Buscar();

                if (dados != null && dados.Count() > 0)
                {
                    viewModel.Servicos = dados.Select(c => new Servicos
                    {
                        Id = c.Id,
                        Nome = c.Nome
                    }).ToList();
                }

                return View(viewModel);
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
            ServicoViewModelNew model = new ServicoViewModelNew();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServicoViewModelNew model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                await _service.Inserir(new Servico { Nome = model.Nome });

                _notyf.Success("O Serviço foi cadastro com sucesso");

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
