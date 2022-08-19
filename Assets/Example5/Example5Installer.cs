using Zenject;
namespace Example5
{
    public class Example5Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<AttackEvent>();
            Container.BindInterfacesAndSelfTo<B>().AsSingle().NonLazy();
            Container.Bind<Main5>().FromComponentInHierarchy().AsCached();
            Container.Bind<A>().AsSingle();
        }
    }
}