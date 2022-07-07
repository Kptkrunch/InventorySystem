using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractible {

    Animator chestAnimator;
    bool isOpen = false;

    void Start() {

        chestAnimator = GetComponent<Animator>();
    }

    public UnityAction<IInteractible> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful) {

        if(isOpen) {
            chestAnimator.Play("CloseChest");
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
            interactSuccessful = false;
            isOpen = false;
            return;
        }

        OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        interactSuccessful = true;
        isOpen = true;
        chestAnimator.Play("OpenChest");

    }

    public void EndInteraction() {
        chestAnimator.Play("CloseChest");
    }
}
