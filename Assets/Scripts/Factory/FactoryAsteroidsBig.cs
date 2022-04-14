using UnityEngine;

namespace Asteroids
{
    internal sealed class FactoryAsteroidsBig
    {
        public static Asteroid Create(int healthPoint)
        {
            Asteroid asteroid = Create();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create()
        {
            return Object.Instantiate(ReferenceAsteroids.Big());
        }
    }
}