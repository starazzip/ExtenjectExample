using Zenject;
//----- Example 1: �[�k ------//
// * ��M�w�g�b��������GameObjecy (FromComponentInHierarchy)
// * �qScene context �����OperatorUser �`�JUserOfAdd
public class Example1Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        // �qProject context ������~��IOperator������Add��� �`�JOperatorUser
        Container.Bind<OperatorUser>()
            .AsSingle(); // Single��ܷ�eContext�u���\�@�ӳo�ع�ҡA�Y���u�w�w�]��AsTransient

        Container.Bind<UserOfAdd>()
            .FromComponentInHierarchy() // �qHierarchy��GameObject -> ���P��GameObject.FindObjectsOfType
            .AsSingle()
            .NonLazy();  // NonLazy��ܹB���o��N���͹�ҡA���u�w�h�����ϥΨ�~�ͦ�
    }
}