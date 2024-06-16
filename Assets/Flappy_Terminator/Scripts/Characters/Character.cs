using System;
using UnityEngine;

namespace Flappy_Terminator
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

        protected int DamageBody = 1;

        private int _health;

        public event Action<int> Health—hanged;

        public int Health => _health;

        private void Awake()
        {
            ResetHealth();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnCollision(collision);
        }

        protected abstract void Die();

        protected abstract void OnCollision(Collider2D collision);

        public void TakeDamage(int damage)
        {
            damage = Mathf.Abs(damage);
            ChangeHealth(-damage);
        }

        private void ChangeHealth(int value)
        {
            _health = Mathf.Clamp((_health + value), 0, _maxHealth);
            Health—hanged?.Invoke(_health);

            if (_health <= 0)
                Die();
        }

        public void ResetHealth()
        {
            _health = _maxHealth;
            Health—hanged?.Invoke(_health);
        }
    }
}
