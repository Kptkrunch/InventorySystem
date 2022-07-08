using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractible {

    private bool isOpen = false;

    Animator chestAnimator;
    InventoryUIController chestUIController;
    private void Start() {
        chestAnimator = GetComponent<Animator>();
        chestUIController = GetComponent<InventoryUIController>();
    }

    public UnityAction<IInteractible> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful) {

        if (!isOpen) {

            chestAnimator.Play("OpenChest");
            OnDynamicInventoryDisplayRequested?.Invoke(primaryInventorySystem);
            interactSuccessful = true;
            isOpen = true;
        } else {

            interactSuccessful = false;
            EndInteraction();
        }   
    }

    public void EndInteraction() {
        chestAnimator.Play("CloseChest");
        chestUIController.inventoryPanel.gameObject.SetActive(false);
        //OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        isOpen = false;
    }
}
