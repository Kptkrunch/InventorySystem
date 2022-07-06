using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicInventoryDisplay : InventoryDisplay
{
    protected override void Start() {
        
        InventoryHolder.OnDynamicInventoryDisplayRequested += RefreshDynamicInventory;
        
        base.Start();
    }

    public void RefreshDynamicInventory(InventorySystem invToDisplay) {
        inventorySystem = invToDisplay;
    }

    public override void AssignSlot(InventorySystem invToDisplay) {


    }

    private void ClearSlots() {

        foreach(var item in transform.Cast<Transform>()) {
            Destroy(item.gameObject);
        }
    }
}
