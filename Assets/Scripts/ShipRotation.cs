using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class ShipRotation : IRotation
    {
        private readonly Transform _transform;
        public ShipRotation(Transform transform)
        {
            _transform = transform;
        }
        public void Rotation(Vector3 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}