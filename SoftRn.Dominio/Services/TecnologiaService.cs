using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Repositories;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Dominio.Services
{
    public class TecnologiaService : ServiceBase<Tecnologia>, ITecnologiaService
    {
        private readonly ITecnologiaRepository _tecnologiaRepository;

        public TecnologiaService(ITecnologiaRepository tecnologiaRepository)
            : base(tecnologiaRepository)
        {
            _tecnologiaRepository = tecnologiaRepository;
        }
    }
}
