using UnityEngine;

namespace Asteroids
{
    public sealed class ControllerInput : IExecute, IFixExecute
    {
        private Vector2 _position;
        private Vector3 _direction;

        private readonly ShipMovement _playerMovement;
        private readonly Transform _playerTransform;
        private readonly Camera _camera;
        private readonly WeaponSystem _playerWeaponBlasters;
        private readonly WeaponSystem _playerWeaponRockets;

        public ControllerInput(Player player, Camera camera)
        {
            _playerTransform = player.transform;
            _playerMovement = player.Movement;
            _playerWeaponBlasters = player.BlasterSystem;
            _playerWeaponRockets = player.RocketSystem;
            _camera = camera;
        }

        public void Execute()
        {
            _position.x = Input.GetAxis(ConstantInput.HORIZONTAL);
            _position.y = Input.GetAxis(ConstantInput.VERTICAL);
            _direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerTransform.position);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerMovement.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerMovement.RemoveAcceleration();
            }
            if (Input.GetButton(ConstantInput.FIRE1))
            {
                _playerWeaponBlasters.Shoot();
            }
            if (Input.GetButton(ConstantInput.FIRE2))
            {
                _playerWeaponRockets.Shoot();
            }
        }

        public void FixExecute()
        {
            _playerMovement.Rotation(_direction);
            _playerMovement.Move(_position.x, _position.y, Time.deltaTime);
        }
    }
}