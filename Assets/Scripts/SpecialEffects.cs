using UnityEngine;

namespace Asteroids
{
    public class SpecialEffects : MonoBehaviour
    {
        [SerializeField] float _aliveTime;
        private void Start()
        {
            Destroy(gameObject, _aliveTime);
        }
    }
}