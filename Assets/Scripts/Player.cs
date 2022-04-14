using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Player : Unit, IExecute
    {
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private Transform[] _transformBlasters;
        [SerializeField] private Transform[] _transformRocketLaunchers;
        public ShipMovement Movement { get; private set; }

        private PoolAmmunition _rocketPool;
        private PoolAmmunition _blasterPool;
        public WeaponSystem RocketSystem { get; private set; }
        public WeaponSystem BlasterSystem { get; private set; }

        private void Awake()
        {
            Health = new Health(_maxHealthPoint);
            Rigidbody2D _rigidBody = GetComponent<Rigidbody2D>();
            ShipRotation _rotation = new ShipRotation(transform);
            MoveRigidBodyAcceleration _move = new MoveRigidBodyAcceleration(_rigidBody, _speed, _acceleration);
            Movement = new ShipMovement(_rotation, _move);

            _rocketPool = new PoolAmmunition(4, ReferenceWeaponSettings.Rocket());
            _blasterPool = new PoolAmmunition(50, ReferenceWeaponSettings.Blaster());

            RocketSystem = new WeaponSystem(_rocketPool, _transformRocketLaunchers, ReferenceWeaponSettings.Rocket());
            BlasterSystem = new WeaponSystem(_blasterPool, _transformBlasters, ReferenceWeaponSettings.Blaster());
        }

        public void Execute()
        {
            RocketSystem.Execute();
            BlasterSystem.Execute();
        }

        public override void Demolition()
        {
            SpecialEffects effect = FactoryFX.CreateExplosionFX();
            effect.transform.position = transform.position;
            Debug.Log("Game Over");
        }

        //Как можно вернуть урон из Collider'а не используя GetComponent и не превратить всё в if\case?

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!Health.IsDemolition)
            {
                if (collision.tag == ConstantTag.ASTEROID) Damage(ConstantWeapon.ASTEROID);
            }
        }
    }
}