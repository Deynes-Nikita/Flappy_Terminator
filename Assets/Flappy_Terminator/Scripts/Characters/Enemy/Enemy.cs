using System;
using UnityEngine;

namespace Flappy_Terminator
{
    public class Enemy : Character
    {
        [SerializeField] private int _reward;

        public event Action<Enemy> Died;
        public event Action<int> GaveReward;

        protected override void Die()
        {
            GaveReward?.Invoke(_reward);
            Died?.Invoke(this);
        }

        protected override void OnCollision(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character target))
            {
                target.TakeDamage(DamageBody);
                Die();
            }

            if (collision.TryGetComponent<DeadZone>(out DeadZone deadZone))
                GotIntoDeadZone();
        }

        private void GotIntoDeadZone()
        {
            Died?.Invoke(this);
        }
    }
}
