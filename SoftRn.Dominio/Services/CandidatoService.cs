using System.Collections.Generic;
using System.Linq;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Repositories;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Dominio.Services
{
    public class CandidatoService : ServiceBase<Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
            : base(candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public IEnumerable<Candidato> BuscarPorVaga(int id)
        {
            return _candidatoRepository.GetAll().Where(c => c.VagaId == id);
        }

        public int QuantCandidatoPorVaga(int idVaga)
        {
            int total = _candidatoRepository.GetAll().Where(c => c.VagaId == idVaga).Count();
            return total;
        }
    }
}
