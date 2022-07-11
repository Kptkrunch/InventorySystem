using UnityEngine.Events;


public interface IInteractible {

    public UnityAction<IInteractible> OnInteractionComplete { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccessful);

    public void EndInteraction();
}
