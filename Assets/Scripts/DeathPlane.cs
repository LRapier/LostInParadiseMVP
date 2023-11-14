using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public GameObject deathMessage;
    public Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D()
    {
        deathMessage.SetActive(true);
        inventory.Die();
        Invoke("Reset", 1.5f);
    }

    void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
