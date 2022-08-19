using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Example4_2
{
    public class Main4_2 : MonoBehaviour
    {
        private Card.Factory cardFactory;
        private List<Card> cards = new List<Card>();

        [Inject]
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

                var card = cardFactory.Create(randomPos, randomPoint);
                cards.Add(card);
            }
            else//超過一百銷毀
            {
                foreach (var c in cards)
                    c.Dispose(); // 歸還給Memory pool (也可以使用using 語法)
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