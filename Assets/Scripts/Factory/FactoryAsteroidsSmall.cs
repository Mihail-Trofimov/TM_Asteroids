using UnityEngine;

namespace Asteroids
{
    internal sealed class FactoryAsteroidsSmall
    {
        public static Asteroid Create(int healthPoint)
        {
            Asteroid asteroid = Create();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create()
        {
            MetodReturnAsteroid[] metods = new MetodReturnAsteroid[]
            {
                Create_1,
                Create_2,
                Create_3,
                Create_4
            };
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
            return Object.Instantiate(ReferenceAsteroids.Small_1());
        }

        public static Asteroid Create_2(int healthPoint)
        {
            Asteroid asteroid = Create_2();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create_2()
        {
            return Object.Instantiate(ReferenceAsteroids.Small_2());
        }

        public static Asteroid Create_3(int healthPoint)
        {
            Asteroid asteroid = Create_3();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create_3()
        {
            return Object.Instantiate(ReferenceAsteroids.Small_3());
        }

        public static Asteroid Create_4(int healthPoint)
        {
            Asteroid asteroid = Create_4();
            asteroid.SetHealth(healthPoint);
            return asteroid;
        }

        public static Asteroid Create_4()
        {
            return Object.Instantiate(ReferenceAsteroids.Small_4());
        }
    }
}