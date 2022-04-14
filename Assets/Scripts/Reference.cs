using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Reference
    {
        private Player _player;
        private Camera _mainCamera;
        public Player player
        {
            get
            {
                if (_player == null)
                {
                    Player gameObject = Resources.Load<Player>("Player");
                    _player = Object.Instantiate(gameObject);
                }
                return _player;
            }
        }
        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }
    }
}

