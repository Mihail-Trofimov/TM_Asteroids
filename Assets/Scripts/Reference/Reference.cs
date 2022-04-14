using UnityEngine;

namespace Asteroids
{
    public class Reference
    {
        private Player _player;
        private Camera _mainCamera;

        public Player Player
        {
            get
            {
                if (_player == null)
                {
                    Player player = Resources.Load<Player>(ConstantPrefabName.PLAYER);
                    _player = Object.Instantiate(player);
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

