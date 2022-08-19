using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Example4
{
    public class Main4 : MonoBehaviour
    {
        private Card.Factory cardFactory;
        private List<Card> cards = new List<Card>();

        [Inject]// 動態生成物件時丟入Factroy，利用Factory產生物件。
                // 取代在Script中New的動作或AddComponent的動作
        private void Constructor(Card.Factory cardFactory)
        {
            this.cardFactory = cardFactory;
        }

        private void Update()
        {
            if (cards.Count < 100) // 生成100個
            {
                Vector2 randomPos = createRandomPos();
                int randomPoint = createRandomPoint();

                // 由於是用New的方式，分配記憶體在heap。成本高
                var card = cardFactory.Create(randomPos, randomPoint);
                cards.Add(card);
            }
            else
            {
                // 生成100個後銷毀
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