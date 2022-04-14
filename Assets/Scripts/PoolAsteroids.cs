using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class PoolAsteroids
    {
        private readonly HashSet<Asteroid> _pool;
        private readonly int _capacity;
        private readonly Transform _root;
        private readonly Asteroid _prefab;
        private readonly string _poolName;

        public PoolAsteroids(int capacity, Asteroid prefab, string poolName )
        {
            _poolName = poolName;
            _prefab = prefab;
            _pool = new HashSet<Asteroid>();
            _capacity = capacity;
            _root = _root = new GameObject(poolName).transform;
        }

        public Asteroid GetAsteroid(string poolName)
        {
            if (_poolName == poolName) 
            {
                Asteroid asteroid = GetFromPool();
                asteroid.gameObject.SetActive(true);
                return asteroid;
            }
            else 
            {
                throw new ArgumentOutOfRangeException("Тип: \"" + poolName + "\" Отличается от заданного \"" + _poolName + "\"");

            }
        }

        private Asteroid GetFromPool()
        {
            Asteroid asteroid = _pool.FirstOrDefault(first => !first.gameObject.activeSelf);
            if (asteroid == null)
            {
                for (var i = 0; i < _capacity; i++)
                {
                    Asteroid instantiate = Object.Instantiate(_prefab);
                    ReturnToPool(instantiate.transform);
                    _pool.Add(instantiate);
                }
                GetFromPool();
            }
            asteroid = _pool.FirstOrDefault(first => !first.gameObject.activeSelf);
            return asteroid;
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