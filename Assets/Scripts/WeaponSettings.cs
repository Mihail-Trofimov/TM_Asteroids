namespace Asteroids
{
    public struct WeaponSettings
    {
        public readonly string PoolName;
        public readonly Ammunition Prefab;
        public readonly float Force;
        public readonly float ReloadTime;

        public WeaponSettings(string name, Ammunition prefab, float force, float reloadTime)
        {
            PoolName = name;
            Prefab = prefab;
            Force = force;
            ReloadTime = reloadTime;
        }
    } 
}