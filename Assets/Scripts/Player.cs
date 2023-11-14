using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerState standState = new StandingState();
    public bool hasKey = false;

    private void Start()
    {
        standState.Enter(this);
        Inventory inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        inventory.Backup();
    }

    private void Update()
    {
        PlayerState state = standState.HandleInput(this);
        if (state != null)
        {
            standState.Exit(this);
            standState = state;
            standState.Enter(this);
        }
        standState.Update(this);
    }
}