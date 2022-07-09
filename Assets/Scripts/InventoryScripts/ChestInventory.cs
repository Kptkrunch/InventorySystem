using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractible {

    private bool isOpen = false;

    //public GameObject chestUIPanel;
    Animator chestAnimator;

    private void Start() {
        chestAnimator = GetComponent<Animator>();
        //chestUIPanel = GameObject.Find("InventoryUIController");
    }

    public UnityAction<IInteractible> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful) {


        if (!isOpen) {

            chestAnimator.Play("OpenChest");
            OnDynamicInventoryDisplayRequested?.Invoke(primaryInventorySystem);
            interactSuccessful = true;
            isOpen = true;
        } else {

            interactSuccessful = true;
            OnDynamicInventoryDisplayRequested?.Invoke(primaryInventorySystem);
            EndInteraction();
        }   
    }

    public void EndInteraction() {
        chestAnimator.Play("CloseChest");
        isOpen = false;
    }
}
