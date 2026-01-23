using System;
using UnityEngine;

[CreateAssetMenu]
public class IntegerVariableSO : ScriptableObject
{
    [TextArea(2, 10)] public string DeveloperDescription = "";
    ///<summary> Raised when new value was set to this var </summary>
    public event Action OnValueChangedHandler;

    [SerializeField] int value;
    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
            OnValueChangedHandler?.Invoke();
        }
    }
}
