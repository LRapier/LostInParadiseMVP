using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraAutoscroll : MonoBehaviour
{
    public Transform playerTr;
    public Vector3 lossPosition;
    public GameObject deathMessage;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        if(transform.position.x >= lossPosition.x)
        {
            deathMessage.SetActive(true);
            Invoke("Reset", 1.5f);
        }
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
