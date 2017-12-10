using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Application
{
    public class VagaAppService : AppServiceBase<Vaga>, IVagaAppService
    {
        private readonly IVagaService _vagaService;

        public VagaAppService(IVagaService vagaService)
            : base(vagaService)
        {
            _vagaService = vagaService;
        }
    }
}
