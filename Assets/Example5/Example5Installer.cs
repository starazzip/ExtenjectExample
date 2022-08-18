using Assets.Example5;
using Zenject;

public class Example5Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<AttackEvent>();
        Container.BindInterfacesAndSelfTo<B>().AsSingle().NonLazy();
        Container.Bind<Main>().FromComponentInHierarchy().AsCached();
        Container.Bind<A>().AsSingle();
    }
}