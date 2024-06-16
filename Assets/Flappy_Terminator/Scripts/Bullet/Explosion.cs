using System;
using UnityEngine;

namespace Flappy_Terminator
{
    [RequireComponent (typeof(Animator))]
    public class Explosion : MonoBehaviour 
    {
        public static readonly int ClipExplosion = Animator.StringToHash("Explosion");

       [SerializeField] private Animator _animator;

        private float _explosionTime = 0.5f;

        public event Action<Explosion> Exploded;

        private void Awake()
        {
            _animator = GetComponent<Animator> ();
        }

        private void OnEnable()
        {
            _animator.Play(ClipExplosion);
            Invoke(nameof(Explode), _explosionTime);
        }

        private void Explode()
        {
            Exploded?.Invoke(this);
        }
    }
}
