using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData ItemData => itemData;
    public int StackSize => stackSize;

    // func overload, will only apply if args are provided
    public InventorySlot(InventoryItemData source, int amount) {
            itemData = source;
            stackSize = amount;
    }
    // func overload, will follow this pattern when no args are provided
    public InventorySlot() {
        ClearSlot();
    }

    public void ClearSlot() {
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount) {
        itemData = data;
        stackSize = amount;
    }
    
    // make sure we check stack size and can't go over
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining) {
        amountRemaining = ItemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd) {
        if(stackSize + amountToAdd <= ItemData.MaxStackSize) {
            return true;
        } else {
            return false;
        }
    }

    // modify stacks amounts
    public void AddToStack(int amount) {
        stackSize += amount;
    }

    public void SubFromStack(int amount) {
        stackSize -= amount;
    }

}
