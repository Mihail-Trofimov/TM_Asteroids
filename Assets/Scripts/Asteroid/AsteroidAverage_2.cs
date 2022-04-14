using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidAverage_2 : Asteroid
    {
        public override void DamageFromAmmo(Quaternion direction)
        {
            if (Health.IsDemolition)
            {
                CreateDebris(FactoryAsteroidsSmall.Create_3(), direction, 0.8f);
                CreateDebris(FactoryAsteroidsSmall.Create_4(), direction, -0.8f);
                Demolition();
            }
        }
    }
}