using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;
namespace Example4_2
{
    // 為需要使用Memory pool的類別掛上IPoolable,和IDisposable。
    // Vector, int為生成物件的初始參數 會藉由呼叫OnSpawned來初始化物件內容
    public class Card : MonoBehaviour, IPoolable<Vector2, int, IMemoryPool>, IDisposable
    {
        [SerializeField] private Text _points;
        [SerializeField] private Image _background;
        private IMemoryPool _pool;
        // MemoryPool 產生物件
        public void OnSpawned(Vector2 pos, int point, IMemoryPool pool)
        {
            transform.localPosition = pos;
            _points.text = point.ToString();
            _pool = pool;
        }
        // MemoryPool 歸還物件
        public void Dispose()
        {
            _pool.Despawn(this);
        }
        public void OnDespawned()
        {
            _pool = null;
        }
        public class Factory : PlaceholderFactory<Vector2, int, Card> { }
    }
}