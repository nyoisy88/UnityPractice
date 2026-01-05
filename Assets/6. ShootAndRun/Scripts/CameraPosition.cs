using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector3 playerPos = Player.Instance.transform.position;
        Vector3 newPosition = new Vector3(playerPos.x, playerPos.y, transform.position.z);
            transform.position = newPosition;
    }
}
