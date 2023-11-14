using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalFinish : MonoBehaviour
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
                if (inventory.inventorySprites[x].sprite == null)
                    break;
                Debug.Log(inventory.inventorySprites[x].sprite.name);
                if (inventory.inventorySprites[x].sprite.name == "Key")
                {
                    inventory.inventorySprites[x].color = new Color(0, 0, 0, 0);
                    inventory.inventorySprites[x].sprite = null;
                    inventory.inventorySpritesReset[x] = null;
                    break;
                }
            }
            winScreen.SetActive(true);
            Invoke("NextScene", 2f);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
