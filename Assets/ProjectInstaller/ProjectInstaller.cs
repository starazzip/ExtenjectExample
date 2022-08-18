using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //For Example 1: 加法
        Container.Bind<IOperator>()
            .To<Add>()
            .WhenInjectedInto<OperatorUser>();

        //For Example 2: 減法
        Container.Bind<IOperator>()
            .To<Sub>()
            .WhenInjectedInto<UserOfSub>();

        //For Example 3: 除法
        Container.Bind<IOperator>()
            .FromInstance(DivSingleton.Instance)
            .WhenInjectedInto<UserOfDiv>();

        //For Example 4: 乘法 memory pool & Factory
        Container.BindFactory<int, Mut, Mut.Factory>()
            .FromMonoPoolableMemoryPool(
            (x) =>
            {
                x.WithInitialSize(10) // 指定pool 的起始size
                .ExpandByDoubling() // 指定Object 超過Size後怎麼擴展
                .FromNewComponentOnNewGameObject();
            });
    }
}