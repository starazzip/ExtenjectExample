using System;
using UnityEngine;
using Zenject;
public class Mut : MonoBehaviour, IOperator, IPoolable<int, IMemoryPool>, IDisposable
{
    public int CaculateCounter { get; private set; }
    private IMemoryPool pool;
    public int DoOprator(int a, int b)
    {
        CaculateCounter++;
        return a * b;
    }

    public void OnDespawned()
    {
        pool = null;
    }

    public void OnSpawned(int count, IMemoryPool p1)
    {
        pool = p1;
        CaculateCounter = count;
    }
    public void Dispose()
    {
        pool.Despawn(this);
    }
    public class Factory : PlaceholderFactory<int, Mut>
    {
    }
}
