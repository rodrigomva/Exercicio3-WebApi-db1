using System.Collections.Generic;
using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Application
{
    public class CandidatoTecnologiaAppService : AppServiceBase<CandidatoTecnologia>, ICandidatoTecnologiaAppService
    {
        private readonly ICandidatoTecnologiaService _candidatoTecnologiaService;

        public CandidatoTecnologiaAppService(ICandidatoTecnologiaService candidatoTecnologiaService)
            : base(candidatoTecnologiaService)
        {
            _candidatoTecnologiaService = candidatoTecnologiaService;
        }

        public IEnumerable<CandidatoTecnologia> BuscarPorCandidato(int id)
        {
            return _candidatoTecnologiaService.BuscarPorCandidato(id);
        }
    }
}
