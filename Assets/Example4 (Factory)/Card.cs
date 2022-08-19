using UnityEngine;
using UnityEngine.UI;
using Zenject;
namespace Example4
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Text _points;
        [SerializeField] private Image _background;
        [Inject]
        private void Constructor(Vector2 pos, int point)
        {
            transform.localPosition = pos;
            _points.text = point.ToString();
        }

        //內嵌工廠類別是推薦的寫法  Vector,int為生成物件的參數 Card為返回的物件類別
        public class Factory : PlaceholderFactory<Vector2, int, Card> { }
    }
}