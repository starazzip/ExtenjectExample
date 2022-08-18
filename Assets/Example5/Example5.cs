using System;
using UnityEngine;
using Zenject;
namespace Assets.Example5
{
    public class AttackEvent { }
    public class A
    {
        private SignalBus _signalBus;
        public A(SignalBus signalBus)
        {
            this._signalBus = signalBus;
        }
        public void Attack()
        {
            this._signalBus.Fire<AttackEvent>();
        }
    }
    public class B : IInitializable, IDisposable
    {
        private SignalBus _signalBus;
        public B(SignalBus signalBus)
        {
            this._signalBus = signalBus;
        }
        public void Initialize()
        {
            _signalBus.Subscribe<AttackEvent>(HandleAttack);
        }
        public void Dispose()
        {
            _signalBus.Unsubscribe<AttackEvent>(HandleAttack);
        }

        public void HandleAttack(AttackEvent e)
        {
            Debug.Log("被 A 攻擊");
        }
    }
}
