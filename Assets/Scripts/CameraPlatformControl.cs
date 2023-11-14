using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlatformControl : MonoBehaviour
{
    public Transform playerTr;
    public Vector3 offset;

    void LateUpdate()
    {
        if (playerTr.localScale.y == 0.5f)
            offset.y = -3;
        else if (playerTr.localScale.y == 1.5f)
            offset.y = 3;
        transform.position = playerTr.position + offset;
    }
}
