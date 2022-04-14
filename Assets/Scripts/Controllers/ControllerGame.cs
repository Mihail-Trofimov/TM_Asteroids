using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class ControllerGame: MonoBehaviour
    {
        [SerializeField] private Transform _spawnAsteroids;
        private readonly Reference _reference = new Reference();
        private ControllerInput _input;
        private Player _player;
        private readonly GameLoop _gameLoop = new GameLoop();

        private void Awake()
        {
            _player = _reference.Player;
            _input = new ControllerInput(_player, _reference.MainCamera);

            _gameLoop.AddExecute(_input);
            _gameLoop.AddFixExecute(_input);
            _gameLoop.AddExecute(_player);
        }

        private void Start()
        {
            SpawnAsteroid();
        }

        private void SpawnAsteroid()
        {
            Debug.Log("SpawnAsteroid");
            Asteroid asteroid = FactoryAsteroids.Create();
            asteroid.transform.position = _spawnAsteroids.position;
            Invoke(nameof(SpawnAsteroid), 10);
        }

        private void Update()
        {
            _gameLoop.Execute();
        }

        private void FixedUpdate()
        {
            _gameLoop.FixExecute();
        }
    }
}