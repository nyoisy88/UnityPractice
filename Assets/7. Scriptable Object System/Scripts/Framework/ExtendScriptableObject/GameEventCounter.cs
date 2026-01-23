using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class GameEventCounter : MonoBehaviour
{
    [SerializeField] private GameEvent eventToListen;
    [SerializeField] private IntegerVariableSO targetVariable;

    [SerializeField] private bool isFailedConfig;

    private void OnValidate()
    {
        isFailedConfig = eventToListen == null || targetVariable == null;
    }
    private void OnEnable()
    {
        if (isFailedConfig) return;
        eventToListen.Subscribe(OnListenEvent);
    }

    private void OnDisable()
    {
        if (isFailedConfig) return;
        eventToListen.Unsubscribe(OnListenEvent);
    }

    private void OnListenEvent()
    {
        targetVariable.Value++;
    }
}
