using System.Collections.Generic;
using System.Linq;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Repositories;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Dominio.Services
{
    public class CandidatoTecnologiaService : ServiceBase<CandidatoTecnologia>, ICandidatoTecnologiaService
    {
        private readonly ICandidatoTecnologiaRepository _candidatoTecnologiaRepository;

        public CandidatoTecnologiaService(ICandidatoTecnologiaRepository candidatoTecnologiaRepository)
            : base(candidatoTecnologiaRepository)
        {
            _candidatoTecnologiaRepository = candidatoTecnologiaRepository;
        }


        public IEnumerable<CandidatoTecnologia> BuscarPorCandidato(int id)
        {
            return _candidatoTecnologiaRepository.GetAll().Where(c => c.CanditadoId == id);
        }

    }
}
