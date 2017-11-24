using Ninject.Modules;
using Teste.Application.Interface;
using Teste.Application.Service;

namespace TesteEDeploy.IoC
{
    public class NinjectBindings : NinjectModule
    {

        public override void Load()
        {
            Bind<ICidadeService>().To<CidadeService>();
        }
    }
}
