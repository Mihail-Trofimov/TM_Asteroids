namespace Asteroids
{
    public static class ReferenceWeaponSettings
    {
        public static WeaponSettings Rocket()
        {
            return new WeaponSettings
            (
                ConstantPoolName.AMMUNITION_ROCKET, 
                ReferenceAmmo.Rocket(), 
                ConstantWeapon.ROCKET_FORCE, 
                ConstantWeapon.ROCKET_RELOAD
            );
        }

        public static WeaponSettings Blaster()
        {
            return new WeaponSettings
            (
                ConstantPoolName.AMMUNITION_BLASTER,
                ReferenceAmmo.Plasma(),
                ConstantWeapon.BLASTER_FORCE,
                ConstantWeapon.BLASTER_RELOAD
            );
        }
    }
}
