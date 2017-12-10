using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Repositories;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Dominio.Services
{
    public class VagaService : ServiceBase<Vaga>, IVagaService
    {
        private readonly IVagaRepository _vagaRepository;

        public VagaService(IVagaRepository vagaRepository)
            : base(vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }
    }
}
