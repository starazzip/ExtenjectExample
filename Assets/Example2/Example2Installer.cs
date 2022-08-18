using Zenject;

//----- Example 2: ��k ------//
// * Bind value ���O (FromInstance)
// * ��M�w�g�b��������GameObjecy (FromComponentInHierarchy)
// * �������h�Ӥ��󪺿��� (Zenject Binding / WithId / [Inject(Id = "titleStr")])
public class Example2Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        // ���w�`�J��MonoOperatorUser���p���D���e
        Container.Bind<string>()
            .WithId("titleStr") // �]�wID�A�t�X" [Inject(Id = "titleStr")]" �ϥ�
            .FromInstance("��k") // �]�wstring���e��"��k" 
            .AsTransient() // �]�����h��string �ҥH����ϥ�AsSingle
            .WhenInjectedInto<UserOfSub>(); // ���w���󬰷�`�JMonoOperatorUser�����

        Container.Bind<string>() // �P�W
            .WithId("BigTitleStr")
            .FromInstance("�j���D")
            .AsTransient()
            .WhenInjectedInto<UserOfSub>();

        Container.Bind<int>() //���O��int
            .WithId("minuend")
            .FromInstance(100) //���w�Q��Ƭ�100
            .AsTransient()
            .WhenInjectedInto<UserOfSub>();

        Container.Bind<int>() //�P�W
            .WithId("subtraction")
            .FromInstance(10) //���w��Ƭ�100
            .AsTransient()
            .WhenInjectedInto<UserOfSub>();

        // Text ���`�J �аѦҳ�������text����
        // 1.��������text���󬰨䱾�WZenject Binding��script
        // 2.�Ntext����Ԧ�components��
        // 3.�]�wIdentifier ��xxx
        // 4.�Ŀ�Use Scene Context
        // ���P�� Container.Bind<Text>().WithId("xxx").FromInstance(���W������);

        Container.Bind<UserOfSub>().FromComponentInHierarchy().AsCached();
    }
}