using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class ControllerGame : MonoBehaviour
    {
        private readonly Reference _reference = new Reference();
        private ControllerInput _input;
        private Player _player;
        private List<IExecute> _execute;
        private List<IFixExecute> _fixExecute;
        void Awake()
        {
            _player = _reference.player;
            _input = new ControllerInput(_player, _reference.MainCamera);

            _execute = new List<IExecute>();
            _execute.Add(_input);

            _fixExecute = new List<IFixExecute>();
            _fixExecute.Add(_input);
        }
        void Update()
        {
            for (int i = 0; i < _execute.Count; i++)
            {
                _execute[i].Execute();
            }
        }
        void FixedUpdate()
        {
            for (int i = 0; i < _fixExecute.Count; i++)
            {
                _fixExecute[i].FixExecute();
            }
        }
    }
}