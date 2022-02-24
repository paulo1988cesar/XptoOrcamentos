using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XptoOrcamentos.Models.OS;
using XptoOrcamentos.Util;

namespace XptoOrcamentos.Controllers
{
    public class OrdemServicoController : Controller
    {
        private readonly IOrdemServicoRepository _ordem;
        private readonly IServicoService _service;
        private readonly IPrestadorService _prestadorService;
        private readonly IContratoService _contratoService;
        private readonly IOrdemServicoService _ordemService;
        private readonly INotyfService _notyf;
        private readonly ILogServiceRepository _log;

        public OrdemServicoController(IOrdemServicoRepository ordem, IServicoService service,
                                      IPrestadorService prestadorService, IContratoService contratoService,
                                      IOrdemServicoService ordemService, INotyfService notyf, 
                                      ILogServiceRepository log)
        {
            _ordem = ordem;
            _service = service;
            _prestadorService = prestadorService;
            _contratoService = contratoService;
            _ordemService = ordemService;
            _notyf = notyf;
            _log = log;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var dados = await _ordem.BuscarOrdem();
                OSViewModel model = new OSViewModel();

                if (dados != null && dados.Count() > 0)
                {
                    model.Ordens = dados.Select(c => new Ordens
                    {
                        Id = c.Id,
                        DataExecucao = c.DateExecucao,
                        NomeCliente = c.Contrato.Nome,
                        NumeroOs = c.NumeroOS,
                        Valor = c.ValorServico,
                        Servico = c.Servico.Nome
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
                OSViewModelNew novaOSViewModel = new OSViewModelNew
                {
                    Servico = await BuscarServicos(),
                    Prestador = await BuscarPrestador(),
                    Contrato = await BuscarContrato()
                };

                return View(novaOSViewModel);
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
        public async Task<ActionResult> Create(OSViewModelNew novaOSViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(novaOSViewModel);

                OrdemServico os = new OrdemServico
                {
                    NumeroOS = MontaNumeroOs(novaOSViewModel),
                    DataAbertura = DateTime.Now,
                    DateExecucao = novaOSViewModel.DataExecucao.Value,
                    IdContrato = novaOSViewModel.IdContrato,
                    IdServico = novaOSViewModel.IdServico,
                    IdPrestador = novaOSViewModel.IdPrestador,
                    ValorServico = Convert.ToDecimal(novaOSViewModel.ValorServico)
                };

                await _ordemService.Inserir(os);

                _notyf.Success($"A OS {os.NumeroOS} foi cadastrada com sucesso", 10);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var dados = _ordem.BuscarOrdem(id);

                if (dados.Result != null)
                {
                    OSViewModelEdit viewModel = new OSViewModelEdit
                    {
                        Servico = await BuscarServicos(),
                        Prestador = await BuscarPrestador(),
                        Contrato = await BuscarContrato(),
                        Id = dados.Result.Id,
                        DataExecucao = dados.Result.DateExecucao,
                        IdContrato = dados.Result.IdContrato,
                        IdPrestador = dados.Result.IdPrestador,
                        IdServico = dados.Result.IdServico,
                        NumeroOS = dados.Result.NumeroOS,
                        ValorServico = dados.Result.ValorServico.ToString()
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
        public async Task<ActionResult> Edit(OSViewModelEdit viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(viewModel);

                OrdemServico os = new OrdemServico
                {
                    Id = viewModel.Id,
                    NumeroOS = viewModel.NumeroOS,
                    DateExecucao = viewModel.DataExecucao.Value,
                    IdContrato = viewModel.IdContrato,
                    IdServico = viewModel.IdServico,
                    IdPrestador = viewModel.IdPrestador,
                    ValorServico = Convert.ToDecimal(viewModel.ValorServico)
                };

                await _ordemService.Atualizar(os);

                _notyf.Success($"A OS {os.NumeroOS} foi atualizada com sucesso", 10);

                return RedirectToAction(nameof(Index));
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ordemService.Excluir(id);

                _notyf.Success("OS foi excluída com sucesso", 10);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await _log.InserirLog(Utils.RetornaObjetoErro(ex));
                _notyf.Error("Ocorreu um erro inesperado, contate o administrador");
                return RedirectToAction(nameof(Index), "Home");
            }
        }

        private string MontaNumeroOs(OSViewModelNew novaOSViewModel)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.Year.ToString());
            sb.Append(DateTime.Now.Month.ToString("00"));
            sb.Append(DateTime.Now.Day.ToString("00"));
            sb.Append(novaOSViewModel.IdContrato);
            sb.Append(novaOSViewModel.IdServico);
            sb.Append(novaOSViewModel.IdPrestador);
            sb.Append("-");
            sb.Append(new Random().Next(1, 1000));
            return sb.ToString();
        }

        private async Task<List<SelectListItem>> BuscarServicos()
        {
            var dados = await _service.Buscar();

            return dados.ToList().Select(c => new SelectListItem()
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            }).ToList();
        }

        private async Task<List<SelectListItem>> BuscarContrato()
        {
            var dados = await _contratoService.Buscar();

            return dados.ToList().Select(c => new SelectListItem()
            {
                Text = $"{c.CNPJ.FormataCNPJ()} - {c.Nome}",
                Value = c.Id.ToString()
            }).ToList();
        }

        private async Task<List<SelectListItem>> BuscarPrestador()
        {
            var dados = await _prestadorService.Buscar();

            return dados.ToList().Select(c => new SelectListItem()
            {
                Text = $"{c.CPF.FormataCPF()} - {c.Nome}",
                Value = c.Id.ToString()
            }).ToList();
        }
    }
}
