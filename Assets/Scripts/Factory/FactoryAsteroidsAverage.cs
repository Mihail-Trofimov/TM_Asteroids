using UnityEngine;

namespace Asteroids
{
    internal sealed class FactoryAsteroidsAverage
    {
        public static Asteroid Create(int healthPoint)
        {
            Asteroid asteroid = Create();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create()
        {
            MetodReturnAsteroid[] metods = new MetodReturnAsteroid[] { Create_1, Create_2 };
            return FactoryAsteroids.RandomMetod(metods)();
        }

        public static Asteroid Create_1(int healthPoint)
        {
            Asteroid asteroid = Create_1();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create_1()
        {
            return Object.Instantiate(ReferenceAsteroids.Average_1());
        }

        public static Asteroid Create_2(int healthPoint)
        {
            Asteroid asteroid = Create_2();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create_2()
        {
            return Object.Instantiate(ReferenceAsteroids.Average_2());
        }
    }
}