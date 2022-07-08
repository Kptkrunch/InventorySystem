using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInventoryDisplay : InventoryDisplay
{   
    [SerializeField] protected InventorySlotUI slotPrefab;

    protected override void Start() {

        InventoryHolder.OnDynamicInventoryDisplayRequested += RefreshDynamicInventory;
        
        base.Start();
        AssignSlot(inventorySystem);
    }

    private void OnDestroy() {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= RefreshDynamicInventory;

    }

    public void RefreshDynamicInventory(InventorySystem invToDisplay) {
    
        ClearSlots();
        inventorySystem = invToDisplay;
        AssignSlot(invToDisplay);
    }

    public override void AssignSlot(InventorySystem invToDisplay) {

        ClearSlots();

        slotDictionary = new Dictionary<InventorySlotUI, InventorySlot>();

        if(invToDisplay == null) {
            return;
        }

        for(int i = 0; i < invToDisplay.InventorySize; i++) {

            var uiSlot = Instantiate(slotPrefab, transform);

            slotDictionary.Add(uiSlot, invToDisplay.InventorySlots[i]);
            uiSlot.Init(invToDisplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }
    }

    private void ClearSlots() {

        foreach(var item in transform.Cast<Transform>()) {
            Destroy(item.gameObject);
        }

        if(slotDictionary != null) {
            slotDictionary.Clear();
        }
    }
}
