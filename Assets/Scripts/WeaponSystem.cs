using UnityEngine;

namespace Asteroids
{
    public sealed class WeaponSystem : IWeapon, IExecute
    {
        private readonly PoolAmmunition _pool;
        private readonly Transform[] _launcherList;
        private bool _isReloaded = false;
        private float _timerReloaded = 0f;
        private readonly WeaponSettings _settings;


        public WeaponSystem(PoolAmmunition poolAmmunition, Transform[] launcherList, WeaponSettings settings)
        {
            _pool = poolAmmunition;
            _launcherList = launcherList;
            _settings = settings;
        }

        public void Execute()
        {
            if(!_isReloaded)
            {
                if (_timerReloaded < _settings.ReloadTime)
                {
                    _timerReloaded += Time.deltaTime;
                }
                else
                {
                    _timerReloaded = 0;
                    _isReloaded = true;
                }
            }
        }

        public void Shoot()
        {
            if (_isReloaded)
            {
                for (int i = 0; i < _launcherList.Length; i++)
                {
                    Ammunition ammo = _pool.GetAmmo(_settings.PoolName);
                    ammo.transform.position = _launcherList[i].position;
                    ammo.transform.rotation = _launcherList[i].rotation;
                    ammo.RigidBody.AddForce(ammo.transform.right * _settings.Force, ForceMode2D.Force);
                    _isReloaded = false;
                }
            }
        }
    }
}