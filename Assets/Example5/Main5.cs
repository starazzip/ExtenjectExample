using UnityEngine;
using Zenject;
namespace Example5
{
    public class Main5 : MonoBehaviour
    {
        private A _a;
        [Inject]
        private void Constructor(A a)
        {
            this._a = a;
        }
        private void Start()
        {
            this._a.Attack();
        }
    }
}