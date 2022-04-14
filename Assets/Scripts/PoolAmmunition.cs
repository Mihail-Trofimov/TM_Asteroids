using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class PoolAmmunition
    {
        private readonly HashSet<Ammunition> _pool;
        private readonly int _capacity;
        private readonly Transform _root;
        private readonly WeaponSettings _settings;

        public PoolAmmunition(int capacity, WeaponSettings settings)
        {
            _settings = settings;
            _pool = new HashSet<Ammunition>();
            _capacity = capacity;
            _root = _root = new GameObject(settings.PoolName).transform;
        }

        public Ammunition GetAmmo(string poolName)
        {
            if (_settings.PoolName == poolName) 
            {
                Ammunition ammo = GetFromPool();
                ammo.gameObject.SetActive(true);
                return ammo;
            }
            else 
            {
                throw new ArgumentOutOfRangeException("Тип: \"" + poolName + "\" Отличается от заданного \"" + _settings.PoolName + "\"");

            }
        }

        private Ammunition GetFromPool()
        {
            Ammunition ammo = _pool.FirstOrDefault(first => !first.gameObject.activeSelf);
            if (ammo == null)
            {
                for (var i = 0; i < _capacity; i++)
                {
                    Ammunition instantiate = Object.Instantiate(_settings.Prefab);
                    ReturnToPool(instantiate.transform);
                    _pool.Add(instantiate);
                }
                GetFromPool();
            }
            ammo = _pool.FirstOrDefault(first => !first.gameObject.activeSelf);
            return ammo;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_root);
        }

        public void RemovePool()
        {
            Object.Destroy(_root.gameObject);
        }
    }
}