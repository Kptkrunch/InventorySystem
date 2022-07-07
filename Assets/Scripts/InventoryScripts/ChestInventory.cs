using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInventory : InventoryHolder, IInteractible {

    Animator chestAnimator;
    bool isOpened;

    void Start() {

        chestAnimator = GetComponent<Animator>();
    }

    public UnityAction<IInteractible> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful) {
        OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        interactSuccessful = true;
        chestAnimator.Play("ChestOpen");

    }

    public void EndInteraction() {

    }
}
