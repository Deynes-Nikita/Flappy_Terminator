using System.Collections;
using UnityEngine;

namespace Flappy_Terminator
{
    public class EnemyShot : Shot
    {
        private void OnEnable()
        {
           StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(RechargeTime);
            yield return waitForSeconds;

            while (enabled)
            {
                BulletSpawner.Shoot();

                yield return waitForSeconds;
            }
        }
    }
}
