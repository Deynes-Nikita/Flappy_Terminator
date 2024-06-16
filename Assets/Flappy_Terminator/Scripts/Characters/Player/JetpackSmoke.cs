using System.Collections;
using UnityEngine;

namespace Flappy_Terminator
{
    public class JetpackSmoke : MonoBehaviour
    {
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private Smoke _smoke;

        private PlayerMover _playerMover;
        private Coroutine _coroutine = null;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
        }

        private void OnEnable()
        {
            _playerMover.Flew += Smoke;
        }

        private void OnDisable()
        {
            _playerMover.Flew += Smoke;
        }

       private void Smoke()
        {
            SmokeSwitch(true);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(GoSmoke());
        }

        private void SmokeSwitch(bool isEnable)
        {
            _smoke.gameObject.SetActive(isEnable);
        }

        private IEnumerator GoSmoke()
        {
            float elapsed = 0;

            while (_delay > elapsed)
            {
                elapsed += Time.deltaTime;
                yield return null;
            }

            _coroutine = null;

            SmokeSwitch(false);
        }
    }
}
