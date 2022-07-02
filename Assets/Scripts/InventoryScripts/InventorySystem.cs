using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]

public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;

    public List<InventorySlot> InventorySlots => inventorySlots;
    public int InventorySize => InventorySlots.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    public InventorySystem(int size) {
        inventorySlots = new List<InventorySlot>(size);

        for(int i = 0; i < size; i++) {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd) {
        if(ContainsItem(itemToAdd, out InventorySlot invSlot)) {
            invSlot.AddToStack(amountToAdd);
            OnInventorySlotChanged?.Invoke(invSlot);
            return true;
        } else if(hasFreeSlot(out InventorySlot freeSlot)) {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public void ContainsItem(InventoryItemData, out InventorySlot invSlot) {
        invSlot = null;
        return false;
    }

    public bool hasFreeSlot(out InventorySlot freeSlot) {
        invSlot = null;
        return false;
    }
}
