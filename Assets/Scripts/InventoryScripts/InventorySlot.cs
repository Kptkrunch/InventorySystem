using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] private int stackSize;

    public InventoryItemData Data => itemData;
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
        StackSize = -1;
    }
    
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining) {
        amountRemaining = itemData.MaxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd) {
        if(stackSize + amountToAdd <= itemData.MaxStackSize) {
            return true;
        } else {
            return false;
        }
    }

    public void AddToStack(int amount) {
        stackSize += amount;
    }

    public void SubFromStack(int amount) {
        stackSize -= amount;
    }

}
