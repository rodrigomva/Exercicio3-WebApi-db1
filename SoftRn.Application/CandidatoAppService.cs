using System.Collections.Generic;
using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Application
{
    public class CandidatoAppService : AppServiceBase<Candidato>, ICandidatoAppService
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoAppService(ICandidatoService candidatoService)
            : base(candidatoService)
        {
            _candidatoService = candidatoService;
        }

        public IEnumerable<Candidato> BuscarPorVaga(int id)
        {
            return _candidatoService.BuscarPorVaga(id);
        }

        public int QuantCandidatoPorVaga(int idVaga)
        {
            return _candidatoService.QuantCandidatoPorVaga(idVaga);
        }
    }
}
