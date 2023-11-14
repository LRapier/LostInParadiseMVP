using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public Image[] inventorySprites;
    public Sprite[] inventorySpritesReset;
    public TextMeshProUGUI pickupMessage;
    public Player player;
    public SecretMenu secretMenu;
    private bool hasSecret = false;
    private string inventorySlotName;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (hasSecret)
            {
                secretMenu = FindAnyObjectByType<SecretMenu>();
                secretMenu.image.color = Color.white;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
            Destroy(this);
        else if (player == null)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            if (pickupMessage == null)
                pickupMessage = GameObject.Find("Item Pickup").GetComponent<TextMeshProUGUI>();
            Debug.Log("Found player inventory");
        }
    }

    public void CollectItem(GameObject pickup)
    {
        SpriteRenderer image = pickup.GetComponent<SpriteRenderer>();
        Collectible collectible = pickup.GetComponent<Collectible>();
        for (int x = 0; x < 3; x++)
        {
            if (inventorySprites[x].sprite == null)
            {
                inventorySprites[x].color = Color.white;
                if (collectible.collectibleType == "Key")
                {
                    player.hasKey = true;
                }
                else if (collectible.collectibleType == "Secret")
                {
                    hasSecret = true;
                }
                inventorySprites[x].sprite = image.sprite;
                pickupMessage.text = "Picked up " + collectible.collectibleType;
                break;
            }
        }
        Invoke("ClearMessage", 1f);
    }

    public void ClearMessage()
    {
        pickupMessage.text = "";
    }

    public void Die()
    {
        for (int x = 0; x < 3; x++)
        {
            inventorySprites[x].sprite = inventorySpritesReset[x];
            if (inventorySprites[x].sprite == null)
                inventorySprites[x].color = new Color(1, 1, 1, 0);
        }
    }

    public void Backup()
    {
        for (int x = 0; x < 3; x++)
        {
            inventorySpritesReset[x] = inventorySprites[x].sprite;
        }
    }
}
