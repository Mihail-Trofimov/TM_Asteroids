using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidAverage_1 : Asteroid
    {
        public override void DamageFromAmmo(Quaternion direction)
        {
            if (Health.IsDemolition)
            {
                CreateDebris(FactoryAsteroidsSmall.Create_1(), direction, 0.8f);
                CreateDebris(FactoryAsteroidsSmall.Create_2(), direction, -0.8f);
                Demolition();
            }
        }
    }
}