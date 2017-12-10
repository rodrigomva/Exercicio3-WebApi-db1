using Exercicio3.Application;
using Exercicio3.Application.Interface;
using Exercicio3.Dominio.Interfaces.Services;
using Exercicio3.Dominio.Services;
using Ninject.Modules;

namespace Exercicio3.Comum.ModuloNinject
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<ITecnologiaService>().To<TecnologiaService>();
            Bind<IVagaService>().To<VagaService>();
            Bind<IVagaPesoService>().To<VagaPesoService>();
            Bind<ICandidatoService>().To<CandidatoService>();
            Bind<ICandidatoTecnologiaService>().To<CandidatoTecnologiaService>();

            //AppService
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<ITecnologiaAppService>().To<TecnologiaAppService>();
            Bind<IVagaAppService>().To<VagaAppService>();
            Bind<IVagaPesoAppService>().To<VagaPesoAppService>();
            Bind<ICandidatoAppService>().To<CandidatoAppService>();
            Bind<ICandidatoTecnologiaAppService>().To<CandidatoTecnologiaAppService>();
        }
    }
}
