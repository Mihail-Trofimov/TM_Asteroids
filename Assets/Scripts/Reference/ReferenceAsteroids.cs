using UnityEngine;

namespace Asteroids
{
    public static class ReferenceAsteroids
    {
        public static Asteroid Big()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_BIG);
        }

        public static Asteroid Average_1()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_AVERAGE_1);
        }

        public static Asteroid Average_2()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_AVERAGE_2);
        }

        public static Asteroid Small_1()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_SMALL_1);
        }

        public static Asteroid Small_2()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_SMALL_2);
        }

        public static Asteroid Small_3()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_SMALL_3);
        }

        public static Asteroid Small_4()
        {
            return Resources.Load<Asteroid>(ConstantPrefabName.ASTEROID_SMALL_4);
        }
    }
}

