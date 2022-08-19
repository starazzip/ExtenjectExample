using Zenject;
//----- Example 3: 除法 ------//
// * 注入Singleton
public class Example3Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UserOfDiv>()
            .FromComponentInHierarchy() // 從Hierarchy找GameObject -> 等同於GameObject.FindObjectsOfType
            .AsSingle()
            .NonLazy(); // NonLazy表示運行到這邊就產生實例，不只定則為有使用到才生成
    }
}