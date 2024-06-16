using System;
using UnityEngine;

namespace Flappy_Terminator
{
    public class BulletSpawner : Spawner<Bullet>
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Character _target;
        [SerializeField] private float _forceShoot = 10;

        public event Action<Vector2> BulletIsHit;

        protected override Bullet CreateFunc()
        {
            Bullet bullet = Instantiate(_bullet);

            bullet.Hit += Release;

            bullet.TakeTarget(_target);

            return bullet;
        }

        protected override void ActionOnGet(Bullet bullet)
        {
            Rigidbody2D rigidbodySpawnedObject = bullet.GetComponent<Rigidbody2D>();
            rigidbodySpawnedObject.velocity = Vector3.zero;
            bullet.transform.rotation = Quaternion.identity;
            bullet.gameObject.SetActive(true);
        }

        protected override void ActionOnRelease(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        protected override void ActionOnDestroy(Bullet bullet)
        {
            bullet.Hit -= Release;
            Destroy(bullet.gameObject);
        }

        protected override void GetSpawnedObject(Vector2 position)
        {
            Bullet bullet = Pool.Get();

            bullet.transform.position = position;
            bullet.transform.rotation = transform.rotation;

            Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
            rigidbodyBullet.velocity = transform.right * _forceShoot;
        }

        protected override void Release(Bullet bullet)
        {
            BulletIsHit?.Invoke(bullet.transform.position);
            Pool.Release(bullet);
        }

        public void Shoot()
        {
            GetSpawnedObject(transform.position);
        }
    }
}