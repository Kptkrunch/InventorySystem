using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] MouseItemData mouseInventoryItem;
    
    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlotUI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<InventorySlotUI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start() {

    }

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void UpdateSlot(InventorySlot updatedSlot) {
        foreach (var slot in SlotDictionary) {
            if(slot.Value == updatedSlot) { // slot value under the hood inv slot
                slot.Key.UpdateUISlot(updatedSlot); // slot key - the UI representation of the value
            }
        }
    }

    public void SlotClicked(InventorySlotUI clickedSlot) {
        Debug.Log("Slot Clicked");
    }
}
