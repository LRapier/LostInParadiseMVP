using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Player player;
    public GameObject winScreen;
    public Inventory inventory;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D()
    {
        if (player.hasKey)
        {
            for (int x = 0; x < 3; x++)
            {
                if (inventory.inventorySprites[x].sprite.name == "Key")
                {
                    inventory.inventorySprites[x].color = new Color(0,0,0,0);
                    inventory.inventorySprites[x].sprite = null;
                    inventory.inventorySpritesReset[x] = null;
                    player.hasKey = false;
                    break;
                }
            }
            winScreen.SetActive(true);
            gameObject.SetActive(false);
            Invoke("NextLevel", 1.5f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
