using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Example4
{
    public class Main4 : MonoBehaviour
    {
        private Card.Factory cardFactory;
        private List<Card> cards = new List<Card>();

        [Inject]// �ʺA�ͦ�����ɥ�JFactroy�A�Q��Factory���ͪ���C
                // ���N�bScript��New���ʧ@��AddComponent���ʧ@
        private void Constructor(Card.Factory cardFactory)
        {
            this.cardFactory = cardFactory;
        }

        private void Update()
        {
            if (cards.Count < 100) // �ͦ�100��
            {
                Vector2 randomPos = createRandomPos();
                int randomPoint = createRandomPoint();

                // �ѩ�O��New���覡�A���t�O����bheap�C������
                var card = cardFactory.Create(randomPos, randomPoint);
                cards.Add(card);
            }
            else
            {
                // �ͦ�100�ӫ�P��
                foreach (var c in cards)
                {
                    Object.DestroyImmediate(c.gameObject);
                }
                cards.Clear();
            }
        }

        private int createRandomPoint()
        {
            return Random.Range(1, 52);
        }

        private Vector2 createRandomPos()
        {
            int x = Random.Range(-Screen.width / 2, Screen.width / 2);
            int y = Random.Range(-Screen.height / 2, Screen.height / 2);
            return new Vector2(x, y);
        }
    }
}