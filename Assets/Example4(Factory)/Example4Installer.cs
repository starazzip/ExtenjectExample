using Zenject;
using UnityEngine;

namespace Example4
{
    // ���d�ҥu�O���F�t��Factory���ϥΤ覡�C
    // ��@�W�|�y���O����}�H�����D�A�n����@�аѦ�Example4-2

    public class Example4Installer : MonoInstaller
    {
        [SerializeField] private Object cardPrefab; //�즲 Card Prefab��Installer�W
        [SerializeField] private Transform cards;   //�즲����ӫ��w�u�t���ͪ�����n��b��
        public override void InstallBindings()
        {
            Container.Bind<Main4>()
                .FromComponentInHierarchy().AsCached().NonLazy();

            // Vector2 ��Inject�Ѽƪ���m
            // int ��Inject�Ѽƪ��I��
            Container.BindFactory<Vector2, int, Card, Card.Factory>()
                .FromComponentInNewPrefab(cardPrefab)
                .UnderTransform(cards);
        }
    }
}