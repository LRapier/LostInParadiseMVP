using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAutoscroller : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.position = new Vector3((transform.position.x + 0.045f), transform.position.y, transform.position.z);
    }
}
