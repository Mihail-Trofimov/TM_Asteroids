using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class WeaponSystem: IWeapon
    {
        private List<WeaponLauncher> _launcherList = new List<WeaponLauncher>();
        private int _currentLauncher = 0;
        public void Add(WeaponLauncher launcher)
        {
            if (!_launcherList.Contains(launcher)) _launcherList.Add(launcher);
        }
        public void Remove(WeaponLauncher launcher)
        {
            if (_launcherList.Contains(launcher)) _launcherList.Remove(launcher);
        }
        public void Shoot()
        {
            _launcherList[_currentLauncher].Shoot();
            Step();
        }
        private void Step()
        {
            _currentLauncher++;
            if (_currentLauncher >= _launcherList.Count) _currentLauncher = 0;
        }
    }
}