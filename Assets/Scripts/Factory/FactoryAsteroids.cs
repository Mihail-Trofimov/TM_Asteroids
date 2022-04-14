using UnityEngine;

namespace Asteroids
{
    internal delegate Asteroid MetodReturnAsteroid();
    internal sealed class FactoryAsteroids
    {
        public static Asteroid Create(int healthPoint)
        {
            Asteroid asteroid = Create();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create()
        {
            MetodReturnAsteroid[] metodsCreate = new MetodReturnAsteroid[]
            {
                FactoryAsteroidsSmall.Create_1,
                FactoryAsteroidsSmall.Create_2,
                FactoryAsteroidsSmall.Create_3,
                FactoryAsteroidsSmall.Create_4,
                FactoryAsteroidsAverage.Create_1,
                FactoryAsteroidsAverage.Create_2,
                FactoryAsteroidsBig.Create
            };
            return RandomMetod(metodsCreate)();
        }

        public static MetodReturnAsteroid RandomMetod(MetodReturnAsteroid[] metodsArray)
        {
            return metodsArray[Random.Range(0, metodsArray.Length)];
        }

        public static Asteroid RandomAsteroid(Asteroid[] prefabsArray)
        {
            return prefabsArray[Random.Range(0, prefabsArray.Length)];
        }
    }
}