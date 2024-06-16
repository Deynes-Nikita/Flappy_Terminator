using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy_Terminator
{
    public class EnemySpawner : Spawner<Enemy>
    {
        [SerializeField] private List<Enemy> _enemys;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private float _repeatRate = 2f;
        [SerializeField] private float _maxPositionYSpawn = 4;
        [SerializeField] private float _minPositionYSpawn = -4;

        private int _enemyIndex = 0;
        private List<Enemy> _enemysInPool = new List<Enemy>();

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        protected override Enemy CreateFunc()
        {
            Enemy enemy = Instantiate(GetEnemy());
            _enemysInPool.Add(enemy);
            enemy.GaveReward += Reward;
            enemy.Died += Release;

            return enemy;
        }

        protected override void ActionOnGet(Enemy enemy)
        {
            enemy.gameObject.SetActive(true);
        }

        protected override void ActionOnRelease(Enemy enemy)
        {
            Rigidbody2D rigidbodySpawnedObject = enemy.GetComponent<Rigidbody2D>();
            rigidbodySpawnedObject.velocity = Vector3.zero;

            enemy.gameObject.SetActive(false);
        }

        protected override void ActionOnDestroy(Enemy enemy)
        {
            enemy.GaveReward -= Reward;
            enemy.Died -= Release;
            Destroy(enemy.gameObject);
        }

        protected override void GetSpawnedObject(Vector2 position)
        {
            Enemy enemy = Pool.Get();
            enemy.transform.position = position;
        }

        protected override void Release(Enemy enemy)
        {
            enemy.ResetHealth();
            Pool.Release(enemy);
        }

        public void Restart()
        {
            foreach (var enemy in _enemysInPool)
            {
                Pool.Release(enemy);
            }
        }

        private Vector2 SetPosition()
        {
            float positionY = Random.Range(_minPositionYSpawn, _maxPositionYSpawn);
            return new Vector2(transform.position.x, positionY);
        }

        private Enemy GetEnemy()
        {
            _enemyIndex = ++_enemyIndex % _enemys.Count;
            return _enemys[_enemyIndex];
        }

        private IEnumerator SpawnEnemy()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(_repeatRate);

            while (enabled)
            {
                GetSpawnedObject(SetPosition());

                yield return waitForSeconds;
            }
        }

        private void Reward (int value)
        {
            _scoreCounter.Add(value);
        }
    }
}