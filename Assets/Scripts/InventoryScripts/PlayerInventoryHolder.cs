using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    [SerializeField] protected int secondaryInventorySize;
    [SerializeField] protected InventorySystem secondaryInventorySystem;

    public InventorySystem SecondInventorySystem => secondaryInventorySystem;
    public static UnityAction<InventorySystem> OnPlayerBPDisplayRequested;

    protected override void Awake() {
        base.Awake();

        secondaryInventorySystem = new InventorySystem(secondaryInventorySize);
    }

    void Update()
    {
        if(Keyboard.current.iKey.wasPressedThisFrame) {
            OnPlayerBPDisplayRequested?.Invoke(secondaryInventorySystem);
        }
    }

    public bool AddToInventory(InventoryItemData data, int amount) {

        if (primaryInventorySystem.AddToInventory(data, amount)) {
            Debug.Log("item added to primary true");
            return true;
        } else if(secondaryInventorySystem.AddToInventory(data, amount)) {
            Debug.Log("item added to secondary true");
            return true;
        }

        return false;
    }
}
