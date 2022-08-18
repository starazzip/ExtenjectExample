using Assets.Example5;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
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
