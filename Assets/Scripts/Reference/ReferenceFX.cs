using UnityEngine;

namespace Asteroids
{
    public static class ReferenceFX
    {
        public static SpecialEffects BlasterFX()
        {
            return Resources.Load<SpecialEffects>(ConstantPrefabName.FX_BLASTER);
        }

        public static SpecialEffects ExplosionFX()
        {
            return Resources.Load<SpecialEffects>(ConstantPrefabName.FX_ROCKET);
        }
    }
}