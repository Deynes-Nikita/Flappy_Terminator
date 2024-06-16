using UnityEngine;
using UnityEngine.UI;

namespace Flappy_Terminator
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private Button _actionButton;

        private CanvasGroup _canvasGroup;

        protected CanvasGroup CanvasGroup => _canvasGroup;
        protected Button ActionButton => _actionButton;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _actionButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _actionButton.onClick.RemoveListener(OnButtonClick);
        }

        protected abstract void OnButtonClick();

        public void Open()
        {
            gameObject.SetActive(true);
        }
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
