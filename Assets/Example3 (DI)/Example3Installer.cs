using Zenject;
//----- Example 3: ���k ------//
// * �`�JSingleton
public class Example3Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UserOfDiv>()
            .FromComponentInHierarchy() // �qHierarchy��GameObject -> ���P��GameObject.FindObjectsOfType
            .AsSingle()
            .NonLazy(); // NonLazy��ܹB���o��N���͹�ҡA���u�w�h�����ϥΨ�~�ͦ�
    }
}