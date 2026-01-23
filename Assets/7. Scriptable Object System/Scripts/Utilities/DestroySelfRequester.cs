using UnityEngine;
public class DestroySelfRequester : MonoBehaviour
{
    public void On_DestroySelf()
    {
        Destroy(gameObject);
    }
}
