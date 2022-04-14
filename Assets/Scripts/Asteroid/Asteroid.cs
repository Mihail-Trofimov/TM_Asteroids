using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Asteroid : Unit
    {
        [SerializeField] private float _speedRotate;
        [SerializeField] private int _maxHealthPoint;
        [SerializeField] private int _force;
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            Animator animator = GetComponent<Animator>();
            animator.speed = _speedRotate;
            Health = new Health(_maxHealthPoint);
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rigidBody.AddForce(-transform.right * _force, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!Health.IsDemolition)
            {
                if (collision.tag == ConstantTag.PLASMA || collision.tag == ConstantTag.ROCKET)
                {
                    Vector3 closestPoint = collision.ClosestPoint(transform.position);
                    SpecialEffects specialEffect;
                    if (collision.tag == ConstantTag.PLASMA)
                    {
                        specialEffect = FactoryFX.CreatePlasmaFX();
                        Damage(ConstantWeapon.BLASTER_DAMAGE);
                    }
                    else 
                    {
                        specialEffect = FactoryFX.CreateExplosionFX();
                        Damage(ConstantWeapon.ROCKET_DAMAGE);
                    }
                    specialEffect.transform.position = closestPoint;

                    DamageFromAmmo(collision.transform.rotation);
                    collision.gameObject.SetActive(false);
                }
            }
        }

        public abstract void DamageFromAmmo(Quaternion direction);

        public void CreateDebris(Asteroid asteroid, Quaternion direction, float offset)
        {
            asteroid.transform.position = new Vector3(transform.position.x, transform.localPosition.y + offset, 0);
            asteroid.transform.rotation = direction;
        }

        public override void Demolition()
        {
            Destroy(gameObject);
            Destroy(this);
        }

    }
}