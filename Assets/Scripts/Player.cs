using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        public Transform[] _blasters;
        public Transform[] _rocketLaunchers;
        public Ship ship;
        public readonly WeaponSystem rocketSystem = new WeaponSystem();
        public readonly WeaponSystem blasterSystem = new WeaponSystem();
        void Awake()
        {
            Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
            ShipRotation _rotation = new ShipRotation(this.transform);
            MoveRigidBodyAcceleration _move = new MoveRigidBodyAcceleration(_rigidBody, _speed, _acceleration);
            ship = new Ship(_rotation, _move);
            ReferenceAmmo _ammoReference = new ReferenceAmmo();
            for (int i = 0; i < _rocketLaunchers.Length; i++)
            {
                WeaponLauncher rocketLoancher = new WeaponLauncher(_ammoReference.Rocket(), _rocketLaunchers[i]);
                rocketSystem.Add(rocketLoancher);
            }
            for (int i = 0; i < _blasters.Length; i++)
            {
                WeaponLauncher blasterLoancher = new WeaponLauncher(_ammoReference.Plasma(), _blasters[i]);
                blasterSystem.Add(blasterLoancher);
            }
        }
    }
}