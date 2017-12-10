using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using AutoMapper;
using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Mvc.ViewModel;

namespace Exercicio3.Mvc.Controllers.Api
{
    public class CandidatoController : ApiController
    {
        private readonly ICandidatoAppService _candidatoApp;
        private readonly ICandidatoTecnologiaAppService _candidatoTecnologiaApp;

        public CandidatoController(ICandidatoAppService candidatoApp, ICandidatoTecnologiaAppService candidatoTecnologiaApp)
        {
            _candidatoApp = candidatoApp;
            _candidatoTecnologiaApp = candidatoTecnologiaApp;
        }

        /// <summary>
        /// Retorna os candidatos da vaga
        /// <param name="id">ID da Vaga</param>
        /// </summary>
        [HttpGet]
        public IEnumerable<CandidatoViewModel> BuscarPorVaga(int id)
        {
            return Mapper.Map<IEnumerable<Candidato>, IEnumerable<CandidatoViewModel>> (_candidatoApp.BuscarPorVaga(id));
        }

        /// <summary>
        /// Retorna candidato por ID
        /// <param name="id">ID do candidato</param>
        /// </summary>
        [HttpGet]
        public CandidatoViewModel BuscarPorId(int id)
        {
            var candidato = _candidatoApp.GetById(id);
            if (candidato == null) return null;
            candidato.Tecnologias = _candidatoTecnologiaApp.BuscarPorCandidato(id);
            return Mapper.Map<Candidato, CandidatoViewModel>(candidato);
        }

        /// <summary>
        /// Cadastra o candidato
        /// <param name="candidato">Class do candidado</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Cadastrar(CandidatoViewModel candidato)
        {
            try { 
                //Validar ModelState
                if (!ModelState.IsValid)
                {
                    foreach (var modelState in ModelState)
                        foreach (ModelError error in modelState.Value.Errors)
                            if (!string.IsNullOrEmpty(error.ErrorMessage))
                                return Request.CreateResponse(HttpStatusCode.BadRequest, error.ErrorMessage);
                }

                var candidatoDomain = Mapper.Map<CandidatoViewModel, Candidato>(candidato);
                _candidatoApp.Add(candidatoDomain);

                //Salva as tecnologias que o candidado conhece
                foreach(var tecnologia in candidatoDomain.Tecnologias)
                {
                    tecnologia.CanditadoId = candidatoDomain.CandidatoId;
                    _candidatoTecnologiaApp.Add(tecnologia);
                }

                return Request.CreateResponse(HttpStatusCode.OK, candidatoDomain);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Exclui o candidato
        /// <param name="candidato">Class do candidato</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Excluir(CandidatoViewModel candidato)
        {
            try
            {
                var candidatoDomain = _candidatoApp.GetById(candidato.CandidatoId);
                candidatoDomain.Tecnologias = _candidatoTecnologiaApp.BuscarPorCandidato(candidato.CandidatoId);

                //Exclui o vinculo das tecnologias
                foreach (var tecnologia in candidatoDomain.Tecnologias)
                {
                    tecnologia.Candidato = null;
                    _candidatoTecnologiaApp.Remove(tecnologia);
                }
                candidatoDomain.Vaga = null;
                _candidatoApp.Remove(candidatoDomain);
                return Request.CreateResponse(HttpStatusCode.OK, candidatoDomain);
            }catch(Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}