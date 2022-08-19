using Zenject;
using UnityEngine;

namespace Example4
{
    // 此範例只是為了演示Factory的使用方式。
    // 實作上會造成記憶體破碎的問題，好的實作請參考Example4-2

    public class Example4Installer : MonoInstaller
    {
        [SerializeField] private Object cardPrefab; //拖曳 Card Prefab到Installer上
        [SerializeField] private Transform cards;   //拖曳物件來指定工廠產生的物件要放在哪
        public override void InstallBindings()
        {
            Container.Bind<Main4>()
                .FromComponentInHierarchy().AsCached().NonLazy();

            // Vector2 為Inject參數的位置
            // int 為Inject參數的點數
            Container.BindFactory<Vector2, int, Card, Card.Factory>()
                .FromComponentInNewPrefab(cardPrefab)
                .UnderTransform(cards);
        }
    }
}