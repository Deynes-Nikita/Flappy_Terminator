using UnityEngine;

namespace Flappy_Terminator
{
    public class PlayerShot : Shot
    {
        private readonly string Fire = "Fire";

        private bool _canShoot;
        private float _elapsed = 0;

        private void Update()
        {
            if (Input.GetAxis(Fire) != 0 && _elapsed >= RechargeTime)
                _canShoot = true;
            else
                _elapsed += Time.deltaTime;

        }
        private void FixedUpdate()
        {
            if (_canShoot)
            {
                Shoot();

                _canShoot = false;
                _elapsed = 0;
            }
        }

        private void Shoot()
        {
            BulletSpawner.Shoot();
        }
    }
}