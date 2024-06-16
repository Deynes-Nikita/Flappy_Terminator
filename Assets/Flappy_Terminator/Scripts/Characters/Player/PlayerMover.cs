using System;
using UnityEngine;

namespace Flappy_Terminator
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        private readonly string Fly = "Fly";

        [SerializeField] private float _tapForse = 5;
        [SerializeField] private float _rotationSpeed = 1;
        [SerializeField] private float _maxRotationZ = 30;
        [SerializeField] private float _minRotationZ = -30;
        [SerializeField] private float _maxPositionY = 4f;

        private Vector3 _startPosition;
        private Rigidbody2D _rigidbody;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;
        private bool _canFly;

        public event Action Flew;

        private void Start()
        {
            _startPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody2D>();

            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        }

        private void Update()
        {
            if (Input.GetAxis(Fly) != 0)
            {
                _canFly = true;
            }
        }

        private void FixedUpdate()
        {
            ToFly();

            ÑheckÑeiling();
        }

        public void ResetPosition()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.identity;
            _rigidbody.velocity = Vector2.zero;
        }

        private void ToFly()
        {
            if (_canFly)
            {
                _rigidbody.velocity = new Vector2(0, _tapForse);
                transform.rotation = _maxRotation;

                Flew?.Invoke();

                _canFly = false;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        private void ÑheckÑeiling()
        {
            if (transform.position.y >= _maxPositionY)
                transform.position = new Vector2(transform.position.x, _maxPositionY);
        }
    }
}
