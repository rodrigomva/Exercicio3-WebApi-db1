using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Entities;
using Exercicio3.Dominio.Interfaces.Services;

namespace Exercicio3.Application
{
    public class TecnologiaAppService : AppServiceBase<Tecnologia>, ITecnologiaAppService
    {
        private readonly ITecnologiaService _tecnologiaService;

        public TecnologiaAppService(ITecnologiaService tecnologiaService)
            : base(tecnologiaService)
        {
            _tecnologiaService = tecnologiaService;
        }
    }
}
