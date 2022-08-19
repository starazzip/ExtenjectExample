using Zenject;
using UnityEngine;
namespace Example4_2
{
    public class Example4_2Installer : MonoInstaller
    {
        [SerializeField] private Object cardPrefab; //�즲 Card Prefab��Installer�W
        [SerializeField] private Transform cards;   //�즲����ӫ��w�u�t���ͪ�����n��b��
        public override void InstallBindings()
        {
            Container.Bind<Main4_2>()
                .FromComponentInHierarchy().AsCached().NonLazy();

            // Vector2 ��Inject�Ѽƪ���m
            // int ��Inject�Ѽƪ��I��
            Container.BindFactory<Vector2, int, Card, Card.Factory>()
                .FromMonoPoolableMemoryPool(
                (x) =>
                {
                    x.WithInitialSize(100) // ���wMemory Pool ��l�j�p
                    .ExpandByDoubling()  // �Y�W�L�HDouble size�X�i
                    .FromComponentInNewPrefab(cardPrefab) // �Ыطs��Prefab
                    .UnderTransform(cards); //���ͥX�Ӫ������b�o��GameObject��
                });
        }
    }
}