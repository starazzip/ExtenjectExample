using Zenject;

//----- Example 2: 減法 ------//
// * Bind value 型別 (FromInstance)
// * 找尋已經在場景中的GameObjecy (FromComponentInHierarchy)
// * 場景中多個元件的辨識 (Zenject Binding / WithId / [Inject(Id = "titleStr")])
public class Example2Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        // 指定注入到MonoOperatorUser的小標題內容
        Container.Bind<string>()
            .WithId("titleStr") // 設定ID，配合" [Inject(Id = "titleStr")]" 使用
            .FromInstance("減法") // 設定string內容為"減法" 
            .AsTransient() // 因為有多個string 所以不能使用AsSingle
            .WhenInjectedInto<UserOfSub>(); // 指定條件為當注入MonoOperatorUser物件時

        Container.Bind<string>() // 同上
            .WithId("BigTitleStr")
            .FromInstance("大標題")
            .AsTransient()
            .WhenInjectedInto<UserOfSub>();

        Container.Bind<int>() //型別為int
            .WithId("minuend")
            .FromInstance(100) //指定被減數為100
            .AsTransient()
            .WhenInjectedInto<UserOfSub>();

        Container.Bind<int>() //同上
            .WithId("subtraction")
            .FromInstance(10) //指定減數為100
            .AsTransient()
            .WhenInjectedInto<UserOfSub>();

        // Text 的注入 請參考場景中的text物件
        // 1.場景中的text元件為其掛上Zenject Binding的script
        // 2.將text元件拉至components中
        // 3.設定Identifier 為xxx
        // 4.勾選Use Scene Context
        // 等同於 Container.Bind<Text>().WithId("xxx").FromInstance(掛上的物件);

        Container.Bind<UserOfSub>().FromComponentInHierarchy().AsCached();
    }
}