using ComputerInterface.Interfaces;
using Zenject;

namespace GorillaSpeech
{
    internal class MainInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IComputerModEntry>().To<GSEntry>().AsSingle();
        }
    }
}