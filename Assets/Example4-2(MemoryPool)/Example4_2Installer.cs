using Zenject;
using UnityEngine;
namespace Example4_2
{
    public class Example4_2Installer : MonoInstaller
    {
        [SerializeField] private Object cardPrefab; //╈Σ Card PrefabInstaller
        [SerializeField] private Transform cards;   //╈Σンㄓ﹚紅玻ネン璶
        public override void InstallBindings()
        {
            Container.Bind<Main4_2>()
                .FromComponentInHierarchy().AsCached().NonLazy();

            // Vector2 Inject把计竚
            // int Inject把计翴计
            Container.BindFactory<Vector2, int, Card, Card.Factory>()
                .FromMonoPoolableMemoryPool(
                (x) =>
                {
                    x.WithInitialSize(100) // ﹚Memory Pool ﹍
                    .ExpandByDoubling()  // 璝禬筁Double size耎甶
                    .FromComponentInNewPrefab(cardPrefab) // 承穝Prefab
                    .UnderTransform(cards); //玻ネㄓン硂GameObjectず
                });
        }
    }
}