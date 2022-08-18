using Assets.Example5;
using Zenject;

public class Example4Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UserOfMut>()
            .FromComponentInHierarchy()
            .AsSingle()
            .NonLazy();  
    }
}