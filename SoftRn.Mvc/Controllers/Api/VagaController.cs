using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using AutoMapper;
using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Mvc.Relatorio;
using Exercicio3.Mvc.Relatorio.View;
using Exercicio3.Mvc.ViewModel;

namespace Exercicio3.Mvc.Controllers.Api
{
    public class VagaController : ApiController
    {
        private readonly IVagaAppService _vagaApp;
        private readonly IVagaPesoAppService _vagaPesoApp;
        private readonly ICandidatoAppService _candidatoApp;
        private readonly ICandidatoTecnologiaAppService _candidatoTecnologiaApp;
        public VagaController(IVagaAppService vagaApp, IVagaPesoAppService vagaPesoApp, ICandidatoAppService candidatoApp, ICandidatoTecnologiaAppService candidatoTecnologiaApp)
        {
            _vagaApp = vagaApp;
            _vagaPesoApp = vagaPesoApp;
            _candidatoApp = candidatoApp;
            _candidatoTecnologiaApp = candidatoTecnologiaApp;
        }

        /// <summary>
        /// Retorna todas as vagas abertas
        /// </summary>
        [HttpGet]
        public IEnumerable<VagaViewModel> BuscarTodasAbertas()
        {
            var vagas = Mapper.Map<IEnumerable<Vaga>, IEnumerable<VagaViewModel>>(_vagaApp.GetAll().Where(v => !v.Encerrado));

            //Busca o total de candidatos de cada vaga
            foreach (VagaViewModel vaga in vagas)
                vaga.TotalCandidatos = _candidatoApp.QuantCandidatoPorVaga(vaga.VagaId);

            return vagas;
        }

        /// <summary>
        /// Retorna todas as vagas encerradas
        /// </summary>
        [HttpGet]
        public IEnumerable<VagaViewModel> BuscarTodasEncerradas()
        {
            var vagas = Mapper.Map<IEnumerable<Vaga>, IEnumerable<VagaViewModel>>(_vagaApp.GetAll().Where(v => v.Encerrado));
            //Busca o total de candidatos de cada vaga
            foreach (VagaViewModel vaga in vagas)
                vaga.TotalCandidatos = _candidatoApp.QuantCandidatoPorVaga(vaga.VagaId);

            return vagas;
        }

        /// <summary>
        /// Busca vaga por ID
        /// <param name="id">ID da Vaga</param>
        /// </summary>
        [HttpGet]
        public VagaViewModel BuscarPorId(int id)
        {
            var vaga = Mapper.Map<Vaga, VagaViewModel>(_vagaApp.GetById(id));
            if (vaga == null) return null;

            //Busca os candidatos vinculados a esta vaga
            vaga.Candidatos = Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoViewModel>>(_candidatoApp.BuscarPorVaga(vaga.VagaId));

            return vaga;
        }

        /// <summary>
        /// Salva a vaga
        /// <param name="vaga">Classa da vaga</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Cadastrar(VagaViewModel vaga)
        {
            try
            {
                //Validar ModelState
                if (!ModelState.IsValid)
                {
                    foreach (var modelState in ModelState)
                        foreach (ModelError error in modelState.Value.Errors)
                            if (!string.IsNullOrEmpty(error.ErrorMessage))
                                return Request.CreateResponse(HttpStatusCode.BadRequest, error.ErrorMessage);
                }

                var vagaDomain = Mapper.Map<VagaViewModel, Vaga>(vaga);
                vagaDomain.Encerrado = false;
                _vagaApp.Add(vagaDomain);
                return Request.CreateResponse(HttpStatusCode.OK, vagaDomain);
            }catch(Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Encerrar a Vaga
        /// <param name="vaga">Class da vaga</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Finalizar(VagaViewModel vaga)
        {
            try
            {
                //Validar ModelState
                if (!ModelState.IsValid)
                {
                    foreach (var modelState in ModelState)
                        foreach (ModelError error in modelState.Value.Errors)
                            if (!string.IsNullOrEmpty(error.ErrorMessage))
                                return Request.CreateResponse(HttpStatusCode.BadRequest, error.ErrorMessage);
                }

                var vagaDomain = Mapper.Map<VagaViewModel, Vaga>(vaga);
                vagaDomain.Encerrado = true;
                _vagaApp.Update(vagaDomain);

                //Salva os pesos de cada tecnologia para esta vaga
                foreach(var vagaPeso in vagaDomain.Pesos)
                {
                    vagaPeso.Vaga = null;
                    vagaPeso.Tecnologia = null;
                    _vagaPesoApp.Add(vagaPeso);
                }

                return Request.CreateResponse(HttpStatusCode.OK, vagaDomain);
            }catch(Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Imprimir o relatório de Desempenho
        /// <param name="id">ID da Vaga</param>
        /// </summary>
        [HttpGet]
        [Route("api/Vaga/Relatorio/{id}")]
        public HttpResponseMessage ImprimirRelatorio(int id)
        {
            try
            {
                var vaga = Mapper.Map<Vaga, VagaViewModel>(_vagaApp.GetById(id));

                //Verifica se encontrou alguma vaga
                if(vaga == null) return Request.CreateResponse(HttpStatusCode.BadRequest, new { content = "Vaga não encontrada" });

                //Verifica se a vaga está encerrada
                if (!vaga.Encerrado) return Request.CreateResponse(HttpStatusCode.BadRequest, new { content = "Vaga ainda não está finalizada, com isso não pode imprimir o relatório" });
                vaga.TotalCandidatos = _candidatoApp.QuantCandidatoPorVaga(vaga.VagaId);

                //Cabeçalho do relatório
                List<VagaRel> cabecalho = new List<VagaRel>();
                var vagaRel = new VagaRel();
                vagaRel.Nome = vaga.Nome;
                vagaRel.Descricao = vaga.Descricao;
                vagaRel.TotalCandidatos = vaga.TotalCandidatos;
                cabecalho.Add(vagaRel);

                //Candidatos
                List<CandidatoRel> candidatosRel = new List<CandidatoRel>();
                var candidatos = _candidatoApp.BuscarPorVaga(vaga.VagaId);
                foreach(var candidato in candidatos)
                {
                    CandidatoRel candidatoRel = new CandidatoRel();
                    candidatoRel.Nome = candidato.Nome;
                    candidatoRel.Email = candidato.Email;
                    candidato.Tecnologias = _candidatoTecnologiaApp.BuscarPorCandidato(candidato.CandidatoId);

                    decimal total = 0;
                    //Calcula o total de pontos de cada candidato
                    foreach(var tecnologia in candidato.Tecnologias)
                        total += _vagaPesoApp.GetAll().FirstOrDefault(c => c.TecnologiaId == tecnologia.TecnologiaId && c.VagaId == candidato.VagaId).Peso;
                    candidatoRel.VagaId = total.ToString();
                    candidatosRel.Add(candidatoRel);
                }

                //Gera o relatório
                var report = new Microsoft.Reporting.WebForms.LocalReport();
                report.ReportPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Relatorio/RelatorioDesempenho.rdlc");
                report.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetVaga", cabecalho));
                report.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetCandidatos", candidatosRel.OrderBy(c => c.VagaId)));
                report.Refresh();
                return ExportarRelatorio.Simples(report);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { content = "Erro ao gerar relatório" });
            }
        }



    }
}