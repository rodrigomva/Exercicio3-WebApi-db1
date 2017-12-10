using Exercicio3.Dados.Repositories;
using Exercicio3.Dominio.Interfaces.Repositories;
using Ninject.Modules;

namespace Exercicio3.Comum.ModuloNinject
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Repository
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<ITecnologiaRepository>().To<TecnologiaRepository>();
            Bind<IVagaRepository>().To<VagaRepository>();
            Bind<IVagaPesoRepository>().To<VagaPesoRepository>();
            Bind<ICandidatoRepository>().To<CandidatoRepository>();
            Bind<ICandidatoTecnologiaRepository>().To<CandidatoTecnologiaRepository>();
        }
    }
}
