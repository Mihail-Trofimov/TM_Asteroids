using System.Collections;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Ammunition : MonoBehaviour
    {
        public Rigidbody2D RigidBody { get; private set; }

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            StartCoroutine(DisableObjectFromTimer());
        }
        private void OnDisable()
        {
            StopCoroutine(DisableObjectFromTimer());
        }

        private IEnumerator DisableObjectFromTimer()
        {
            yield return new WaitForSeconds(2.5f);
            RigidBody.velocity = new Vector3(0, 0, 0);
            gameObject.SetActive(false);
        }
    }
}