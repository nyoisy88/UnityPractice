using System;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingGround
{
    public class PauseUI : MonoBehaviour
    {
        public static PauseUI Instance {  get; private set; }

        [SerializeField] private Slider sensSlider;
        [SerializeField] private Slider speedSlider;

        public event Action<float> OnSensChanged;
        public event Action<float> OnSpeedChanged;


        private bool isShown = true;

        private void Awake()
        {
            Instance = this;
            sensSlider.value = 1;
            speedSlider.value = 1;
            sensSlider.onValueChanged.AddListener((value) =>
            {
                OnSensChanged?.Invoke(value);
            });
            speedSlider.onValueChanged.AddListener(value =>
            {
                OnSpeedChanged?.Invoke(value);
            });
        
        }

        private void Start()
        {
            Show();
        }


        public void Show()
        {
            Time.timeScale = isShown ? 1f : 0f;
            gameObject.SetActive(!isShown);
            Cursor.lockState = isShown ? CursorLockMode.Locked : CursorLockMode.None;
            isShown = !isShown;
        }
    }
}
