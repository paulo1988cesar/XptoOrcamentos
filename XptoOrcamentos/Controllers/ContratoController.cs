using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using XptoOrcamentos.Models.Contrato;
using XptoOrcamentos.Util;

namespace XptoOrcamentos.Controllers
{
    public class ContratoController : Controller
    {

        private readonly INotyfService _notyf;
        private readonly IContratoService _contratoService;
        private readonly ILogServiceRepository _log;

        public ContratoController(IContratoService contratoService, INotyfService notyf,
                                  ILogServiceRepository log)
        {
            _notyf = notyf;
            _log = log;
            _contratoService = contratoService;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var dados = await _contratoService.Buscar();
                ContratoViewModel contratos = new ContratoViewModel();

                if (dados != null && dados.Count() > 0)
                {
                    contratos.Contratos = dados.Select(c => new ContratoCliente
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Cidade = c.Cidade,
                        CNPJ = c.CNPJ.FormataCNPJ()
                    }).ToList();
                }

                return View(contratos);
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
            ContratoViewModelNew viewModel = new ContratoViewModelNew();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContratoViewModelNew viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);

                await _contratoService.Inserir(new Contrato
                {
                    Bairro = viewModel.Bairro,
                    CEP = viewModel.CEP,
                    Cidade = viewModel.Cidade,
                    CNPJ = viewModel.CNPJ,
                    Complemento = viewModel.Complemento,
                    Estado = viewModel.Estado,
                    Logradouro = viewModel.Logradouro,
                    Nome = viewModel.Nome
                });

                _notyf.Success("O Contrato foi cadastrado com sucesso");

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var dados = await _contratoService.Buscar(id);

                if (dados != null)
                {
                    ContratoViewModelEdit viewModel = new ContratoViewModelEdit
                    {
                        Id = dados.Id,
                        Bairro = dados.Bairro,
                        CEP = dados.CEP,
                        Cidade = dados.Cidade,
                        CNPJ = dados.CNPJ,
                        Complemento = dados.Complemento,
                        Estado = dados.Estado,
                        Logradouro = dados.Logradouro,
                        Nome = dados.Nome
                    };

                    return View(viewModel);
                }

                return View();
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
        public async Task<ActionResult> Edit(ContratoViewModelEdit viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);

                await _contratoService.Atualizar(new Contrato
                {
                    Id = viewModel.Id,
                    Bairro = viewModel.Bairro,
                    CEP = viewModel.CEP,
                    Cidade = viewModel.Cidade,
                    CNPJ = viewModel.CNPJ,
                    Complemento = viewModel.Complemento,
                    Estado = viewModel.Estado,
                    Logradouro = viewModel.Logradouro,
                    Nome = viewModel.Nome
                }); ;

                _notyf.Success("O Contrato foi atualizado com sucesso");

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
