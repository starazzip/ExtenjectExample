using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        //For Example 1: �[�k
        Container.Bind<IOperator>()
            .To<Add>()
            .WhenInjectedInto<OperatorUser>();

        //For Example 2: ��k
        Container.Bind<IOperator>()
            .To<Sub>()
            .WhenInjectedInto<UserOfSub>();

        //For Example 3: ���k
        Container.Bind<IOperator>()
            .FromInstance(DivSingleton.Instance)
            .WhenInjectedInto<UserOfDiv>();

        //For Example 4: ���k memory pool & Factory
        Container.BindFactory<int, Mut, Mut.Factory>()
            .FromMonoPoolableMemoryPool(
            (x) =>
            {
                x.WithInitialSize(10) // ���wpool ���_�lsize
                .ExpandByDoubling() // ���wObject �W�LSize�����X�i
                .FromNewComponentOnNewGameObject();
            });
    }
}