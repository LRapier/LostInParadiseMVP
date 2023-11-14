using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPlatformer : MonoBehaviour
{
    public Transform playerTr;
    public Vector3 offset;

    void Update()
    {
        if (playerTr.localScale.y == 0.5f)
            offset.y = -3;
        else if (playerTr.localScale.y == 1.5f)
            offset.y = 3;
        transform.position = new Vector3((playerTr.position.x + offset.x) * .95f, playerTr.position.y + offset.y, playerTr.position.z + offset.z);
    }
}
