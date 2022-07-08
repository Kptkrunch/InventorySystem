using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractible {

    private bool isOpen = false;

    Animator chestAnimator;
    private void Awake() {
        chestAnimator = GetComponent<Animator>();
    }

    public UnityAction<IInteractible> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful) {

        if (!isOpen) {

            chestAnimator.Play("OpenChest");
            OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
            interactSuccessful = true;
            isOpen = true;
        } else {

            chestAnimator.Play("CloseChest");
            //OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
            interactSuccessful = true;
            isOpen = false;
        }   
    }

    public void EndInteraction() {

    }
}
