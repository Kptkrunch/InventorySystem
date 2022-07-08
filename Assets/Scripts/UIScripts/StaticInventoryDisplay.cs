using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaticInventoryDisplay : InventoryDisplay
{   
    [SerializeField] private InventoryHolder inventoryHolder;
    [SerializeField] private InventorySlotUI[] slots;

    protected override void Start() {
        base.Start();

        if(inventoryHolder != null) {
            inventorySystem = inventoryHolder.PrimaryInventorySystem;
            inventorySystem.OnInventorySlotChanged += UpdateSlot;
        } else {
            Debug.LogWarning($"No inventory assigned to {this.gameObject}");
        }

        AssignSlot(inventorySystem);
    }

    public override void AssignSlot(InventorySystem invToDisplay) {
        slotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        if (slots.Length != inventorySystem.InventorySize) {
            Debug.LogWarning($"Inventory Slots out of sysnc on {this.gameObject}");
        }

        for(int i = 0; i < inventorySystem.InventorySize; i++) {

            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init(inventorySystem.InventorySlots[i]);
        }
    }

}
