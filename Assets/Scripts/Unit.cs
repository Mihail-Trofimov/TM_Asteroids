using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Unit : MonoBehaviour, IDamage
    {
        public Health Health { get; protected set; }

        public void Damage(int damage)
        {
            Health.Damage(damage);
            if (Health.IsDemolition) Demolition();
        }

        public abstract void Demolition();

        public void SetHealth(int health)
        {
            Health.SetHealth(health);
        }
    }
}