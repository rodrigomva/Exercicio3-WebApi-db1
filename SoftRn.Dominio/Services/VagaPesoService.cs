using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Repositories;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Dominio.Services
{
    public class VagaPesoService : ServiceBase<VagaPeso>, IVagaPesoService
    {
        private readonly IVagaPesoRepository _vagaPesoRepository;

        public VagaPesoService(IVagaPesoRepository vagaPesoRepository)
            : base(vagaPesoRepository)
        {
            _vagaPesoRepository = vagaPesoRepository;
        }
    }
}
