using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class ControllerInput : IExecute, IFixExecute
    {
        Vector2 _position;
        Vector3 _direction;
        private readonly Player _player;
        private readonly Camera _camera;
        public ControllerInput(Player player, Camera camera)
        {
            _player = player;
            _camera = camera;
        }
        public void Execute()
        {
            _position.x = Input.GetAxis("Horizontal");
            _position.y = Input.GetAxis("Vertical");
            _direction = Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _player.ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _player.ship.RemoveAcceleration();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                _player.blasterSystem.Shoot();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                _player.rocketSystem.Shoot();
            }
        }

        public void FixExecute()
        {
            _player.ship.Rotation(_direction);
            _player.ship.Move(_position.x, _position.y, Time.deltaTime);
        }
    }
}