using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Application
{
    public class VagaPesoAppService : AppServiceBase<VagaPeso>, IVagaPesoAppService
    {
        private readonly IVagaPesoService _vagaPesoService;

        public VagaPesoAppService(IVagaPesoService vagaPesoService)
            : base(vagaPesoService)
        {
            _vagaPesoService = vagaPesoService;
        }
    }
}
