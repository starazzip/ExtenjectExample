using Zenject;
//----- Example 1: 加法 ------//
// * 找尋已經在場景中的GameObjecy (FromComponentInHierarchy)
// * 從Scene context 中找到OperatorUser 注入UserOfAdd
public class Example1Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        // 從Project context 中找到繼承IOperator介面的Add實例 注入OperatorUser
        Container.Bind<OperatorUser>()
            .AsSingle(); // Single表示當前Context只允許一個這種實例，若不只定預設為AsTransient

        Container.Bind<UserOfAdd>()
            .FromComponentInHierarchy() // 從Hierarchy找GameObject -> 等同於GameObject.FindObjectsOfType
            .AsSingle()
            .NonLazy();  // NonLazy表示運行到這邊就產生實例，不只定則為有使用到才生成
    }
}