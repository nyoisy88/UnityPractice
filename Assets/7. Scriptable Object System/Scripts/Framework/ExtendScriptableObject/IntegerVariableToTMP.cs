using TMPro;
using UnityEngine;

public class IntegerVariableToTMP : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private TextMeshProUGUI displayText;
    
    [SerializeField] private IntegerVariableSO variableToFollow;
    [SerializeField] private string textFormat;

    [Header("Validation")]
    [SerializeField] bool isFailedConfig;
    void OnValidate()
    {
        Debug.Assert(displayText != null, "Missing DisplayText");
        isFailedConfig = displayText == null || variableToFollow == null;
        displayText.text = string.Format(textFormat, variableToFollow.Value);
    }

    void OnEnable()
    {
        if (isFailedConfig)
            return;
        variableToFollow.OnValueChangedHandler += IntegerVariableSO_OnValueChanged;
    }

    void OnDisable()
    {
        if (isFailedConfig)
            return;
        variableToFollow.OnValueChangedHandler -= IntegerVariableSO_OnValueChanged;
    }

    private void IntegerVariableSO_OnValueChanged()
    {
        displayText.text = string.Format(textFormat, variableToFollow.Value.ToString());
    }
}
