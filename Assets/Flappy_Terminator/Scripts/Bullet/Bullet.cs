using System;
using UnityEngine;

namespace Flappy_Terminator
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;
        private Character _target;

        public event Action<Bullet> Hit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Character>(out Character target))
            {
                if (target.GetType() == _target.GetType())
                {
                    target.TakeDamage(_damage);
                    Hit?.Invoke(this);
                }
            }

            if (collision.TryGetComponent<DeadZone>(out DeadZone deadZone))
            {
                Hit?.Invoke(this);
            }
        }

        public void TakeTarget(Character target)
        {
            _target = target;
        }
    }
}
