using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy_Terminator
{
    [RequireComponent(typeof(Image))]
    public class Heart : MonoBehaviour
    {
        [SerializeField] private float _lerpDuration;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.fillAmount = 1;
        }

        public void ToFill()
        {
            StartCoroutine(Filling(0, 1, _lerpDuration, Fill));
        }

        public void ToEmpty()
        {
            StartCoroutine(Filling(1, 0, _lerpDuration, Destroy));
        }

        private void Fill(float value)
        {
            _image.fillAmount = value;
        }

        private void Destroy(float value)
        {
            _image.fillAmount = value;
            Destroy(gameObject);
        }

        private IEnumerator Filling(float startWalue, float endWalue, float duration, Action<float> lerpingEnd)
        {
            float elapsed = 0;
            float nextValue;

            while (elapsed < duration)
            {
                nextValue = Mathf.Lerp(startWalue, endWalue, elapsed / duration);
                _image.fillAmount = nextValue;
                elapsed += Time.deltaTime;
                yield return null;
            }

            lerpingEnd?.Invoke(endWalue);
        }
    }
}
