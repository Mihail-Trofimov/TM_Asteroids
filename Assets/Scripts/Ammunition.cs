using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Ammunition : MonoBehaviour
    {
        [SerializeField] private float _force;
        Rigidbody2D _rigidBody;
        void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            _rigidBody.AddForce(this.transform.right * _force);
        }
    }
}