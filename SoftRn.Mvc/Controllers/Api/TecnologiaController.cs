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
using Exercicio3.Mvc.ViewModel;

namespace Exercicio3.Mvc.Controllers.Api
{
    public class TecnologiaController : ApiController
    {
        private readonly ITecnologiaAppService _tecnlogiaApp;

        public TecnologiaController(ITecnologiaAppService tecnlogiaApp)
        {
            _tecnlogiaApp = tecnlogiaApp;
        }

        /// <summary>
        /// Retorna todas as tecnologias
        /// </summary>
        [HttpGet]
        public IEnumerable<TecnologiaViewModel> BuscarTodos()
        {
            return Mapper.Map<IEnumerable<Tecnologia>, IEnumerable<TecnologiaViewModel>>(_tecnlogiaApp.GetAll()); 
        }

        /// <summary>
        /// Retorna apenas as tecnologias ativas
        /// </summary>
        [HttpGet]
        public IEnumerable<TecnologiaViewModel> BuscarTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Tecnologia>, IEnumerable<TecnologiaViewModel>>(_tecnlogiaApp.GetAll().Where(t => t.Status));
        }

        /// <summary>
        /// Buscara tecnologia por ID
        /// <param name="id">ID da tecnologia</param>
        /// </summary>
        [HttpGet]
        public TecnologiaViewModel BuscaPorId(int id)
        {
            return Mapper.Map<Tecnologia, TecnologiaViewModel > (_tecnlogiaApp.GetById(id));
        }

        /// <summary>
        /// Salva a tecnologia
        /// <param name="tecnologia">Class da tecnologia</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Cadastrar(TecnologiaViewModel tecnologia)
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

                var tecnologiaDomain = Mapper.Map<TecnologiaViewModel, Tecnologia>(tecnologia);
                _tecnlogiaApp.Add(tecnologiaDomain);
                return Request.CreateResponse(HttpStatusCode.OK, tecnologiaDomain);
            }catch(Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Edita a tecnologia
        /// <param name="tecnologia">Class da tecnologia</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Editar(TecnologiaViewModel tecnologia)
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

                var tecnologiaDomain = Mapper.Map<TecnologiaViewModel, Tecnologia>(tecnologia);
                _tecnlogiaApp.Update(tecnologiaDomain);
                return Request.CreateResponse(HttpStatusCode.OK, tecnologiaDomain);
            }catch(Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// Exclui a tecnologia
        /// <param name="tecnologia">Class da tecnologia</param>
        /// </summary>
        [HttpPost]
        public HttpResponseMessage Excluir(TecnologiaViewModel tecnologia)
        {
            try
            {
                //Busca tecnologia por ID
                var tecnologiaDomain = _tecnlogiaApp.GetById(tecnologia.TecnologiaId);
                tecnologiaDomain.Status = false;

                //Atualiza a tecnologia para status = false
                _tecnlogiaApp.Update(tecnologiaDomain);
                return Request.CreateResponse(HttpStatusCode.OK, tecnologiaDomain);
            }catch(Exception e){
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}