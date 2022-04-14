using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidSmall : Asteroid
    {
        public override void DamageFromAmmo(Quaternion direction)
        {
            if (Health.IsDemolition) Demolition();
        }
    }
}