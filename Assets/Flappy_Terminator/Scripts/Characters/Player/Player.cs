using System;
using UnityEngine;

namespace Flappy_Terminator
{
    [RequireComponent (typeof(PlayerMover))]
    public class Player : Character
    {
        private PlayerMover _playerMover;

        public event Action GameOver;

        private void Start()
        {
            _playerMover = GetComponent<PlayerMover> ();
        }

        protected override void Die()
        {
            GameOver?.Invoke ();
        }

        protected override void OnCollision(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character target))
            {
                target.TakeDamage(DamageBody);
            }

            if (collision.TryGetComponent<DeadZone>(out DeadZone deadZone))
                Die();
        }

        public void ResetParemetrs()
        {
            _playerMover.ResetPosition();
            ResetHealth();
        }
    }
}