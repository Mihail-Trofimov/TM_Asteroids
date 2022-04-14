using UnityEngine;

namespace Asteroids
{
    public static class ReferenceAmmo
    {
        public static Ammunition Rocket()
        {
            return Resources.Load<Ammunition>(ConstantPrefabName.ROCKET);
        }

        public static Ammunition Plasma()
        {
            return Resources.Load<Ammunition>(ConstantPrefabName.PLASMA);
        }
    }
}

