using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal static class FactoryFX
    {
        public static SpecialEffects CreatePlasmaFX()
        {
            return Object.Instantiate(ReferenceFX.BlasterFX());
        }

        public static SpecialEffects CreateExplosionFX()
        {
            return Object.Instantiate(ReferenceFX.ExplosionFX());
        }
    }
}