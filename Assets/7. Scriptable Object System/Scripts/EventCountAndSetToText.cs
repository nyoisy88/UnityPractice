using TMPro;
using UnityEngine;
namespace SOSystem
{
    public class EventCountAndSetToText : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private TextMeshProUGUI displayText;

        [Header("Config")]
        [SerializeField] private EventID eventID;
        [SerializeField] private string textFormat;

        [Header("Validation")]
        [SerializeField] bool isFailedConfig;
        void OnValidate()
        {
            Debug.Assert(displayText != null, "Missing DisplayText");
            isFailedConfig = displayText == null;
        }

        void OnEnable()
        {
            if (isFailedConfig)
                return;
            _count = 0;
            this.Subcribe(eventID, OnEventFired);
            displayText.text = string.Format(textFormat, _count);
        }

        void OnDisable()
        {
            if (isFailedConfig)
                return;
            if (EventDispatcher.HasInstance())
            {
                this.Unsubcribe(eventID, OnEventFired);
            }
        }

        private int _count;
        private void OnEventFired(object param = null)
        {
            _count++;
            displayText.text = string.Format(textFormat, _count);
        }
    }
}
