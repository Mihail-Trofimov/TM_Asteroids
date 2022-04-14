using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidBig : Asteroid
    {
        public override void DamageFromAmmo(Quaternion direction)
        {
            if (Health.IsDemolition)
            {
                CreateDebris(FactoryAsteroidsAverage.Create_1(), direction, 1.7f);
                CreateDebris(FactoryAsteroidsAverage.Create_2(), direction, -1.7f);
                Demolition();
            }
        }
    }
}