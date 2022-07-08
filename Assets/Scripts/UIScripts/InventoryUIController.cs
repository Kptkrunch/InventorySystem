using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{   
    public DynamicInventoryDisplay inventoryPanel;

    private void Awake() {
        inventoryPanel.gameObject.SetActive(false);
    }

    private void OnEnable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
    }

    private void OnDisable() {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
    }

    void Update() {
        if(Keyboard.current.bKey.wasPressedThisFrame) {
            
            DisplayInventory(new InventorySystem(20));
            Debug.Log("B was pressed");
        }

        if(inventoryPanel.gameObject.activeInHierarchy && Keyboard.current.rKey.wasPressedThisFrame) {
            inventoryPanel.gameObject.SetActive(false);
        }
    }

    void DisplayInventory(InventorySystem invToDisplay) {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.RefreshDynamicInventory(invToDisplay);
    }
}
