using UnityEngine;

namespace Flappy_Terminator
{
    public class ExplosionSpawner : Spawner<Explosion>
    {
        [SerializeField] private Explosion _explosion;
        [SerializeField] private BulletSpawner _bulletSpawner;

        private void OnEnable()
        {
            _bulletSpawner.BulletIsHit += GetSpawnedObject;
        }

        private void OnDisable()
        {
            _bulletSpawner.BulletIsHit -= GetSpawnedObject;
        }

        protected override Explosion CreateFunc()
        {
            Explosion explosion = Instantiate(_explosion);
            explosion.Exploded += Release;

            return explosion;
        }

        protected override void ActionOnGet(Explosion explosion)
        {
            explosion.gameObject.SetActive(true);
        }

        protected override void ActionOnRelease(Explosion explosion)
        {
            explosion.gameObject.SetActive(false);
        }

        protected override void ActionOnDestroy(Explosion explosion)
        {
            explosion.Exploded -= Release;
            Destroy(explosion);
        }

        protected override void GetSpawnedObject(Vector2 position)
        {
            Explosion explosion = Pool.Get();
            explosion.transform.position = position;
        }

        protected override void Release(Explosion explosion)
        {
            Pool.Release(explosion);
        }
    }
}
