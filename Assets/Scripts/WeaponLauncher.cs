using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class WeaponLauncher: IWeapon
    {
        private Ammunition _ammoPrefab;
        private Transform _transform;
        public WeaponLauncher(Ammunition prefab, Transform transform)
        {
            _ammoPrefab = prefab;
            _transform = transform;
        }
        public void Shoot()
        {
            Object.Instantiate(_ammoPrefab, _transform.position, _transform.rotation);
        }
    }
}