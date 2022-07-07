using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius = 1f;
    public bool IsInteracting { get; set; }

    private void Update() {

        var colliders = Physics.OverlapSphere(InteractionPoint.position, InteractionPointRadius, InteractionLayer);

        if (Keyboard.current.eKey.wasPressedThisFrame) {
            for (int i = 0; i < colliders.Length; i++) {
                var interactible = colliders[i].GetComponent<IInteractible>();

                if (interactible != null) {
                    StartInteraction(interactible);
                }
            }
        }
    }

    void StartInteraction(IInteractible interactible) {

        interactible.Interact(this, out bool interactSuccessful);
        IsInteracting = true;
    }

    void EndInteraction() {
        IsInteracting = false;
    }

}
