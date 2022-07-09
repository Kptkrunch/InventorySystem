using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{   
    public DynamicInventoryDisplay chestPanel;
    public DynamicInventoryDisplay playerBPPanel;

    private bool isOpen;

    private void Awake() {
        chestPanel.gameObject.SetActive(false);
    }

    private void OnEnable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBPDisplayRequested += DisplayPlayerBP;
    }

    private void OnDisable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerBPDisplayRequested -= DisplayPlayerBP;
    }

    void Update() {
        /* 
        if(Keyboard.current.bKey.wasPressedThisFrame) {
            
            DisplayInventory(new InventorySystem(20));
            Debug.Log("B was pressed");
        } 
        */

        if(chestPanel.gameObject.activeInHierarchy && Keyboard.current.rKey.wasPressedThisFrame) {
            chestPanel.gameObject.SetActive(false);
        }

        if (playerBPPanel.gameObject.activeInHierarchy && Keyboard.current.rKey.wasPressedThisFrame) {
            playerBPPanel.gameObject.SetActive(false);
        }
    }

    void DisplayInventory(InventorySystem invToDisplay) {
        chestPanel.gameObject.SetActive(true);
        chestPanel.RefreshDynamicInventory(invToDisplay);
    }

    void DisplayPlayerBP(InventorySystem invToDisplay) {
        playerBPPanel.gameObject.SetActive(true);
        playerBPPanel.RefreshDynamicInventory(invToDisplay);
    }
}
