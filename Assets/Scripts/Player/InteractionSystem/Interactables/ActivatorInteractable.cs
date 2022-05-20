using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] List<GameObject> interactableGameObjectList;

    public void Interact(Interactor interactor)
    {
        foreach (var gameObject in interactableGameObjectList)
        {
            IInteractable[] interactables = gameObject.GetComponentsInChildren<IInteractable>();
            foreach (var interactable in interactables)
            {
                interactable.Interact(interactor);
            }
        }
    }
}
