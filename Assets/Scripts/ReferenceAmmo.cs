using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class ReferenceAmmo
    {
        public Ammunition Rocket()
        {
            Ammunition _rocket = Resources.Load<Ammunition>("Rocket");
            return _rocket;
        }
        public Ammunition Plasma()
        {
            Ammunition _plasma = Resources.Load<Ammunition>("Plasma");
            return _plasma;
        }
    }
}

