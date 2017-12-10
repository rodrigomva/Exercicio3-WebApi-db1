using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Exercicio3.Comum.ModuloNinject
{
    public class IoC
    {
        public IKernel Kernel { get; set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        private IKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new RepositoryNinjectModule(),
                new InfrastructureNinjectModule()
            );
        }
    }
}
