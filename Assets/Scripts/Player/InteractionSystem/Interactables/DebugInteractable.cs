using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] string debugString = "Interacting...";
    public void Interact(Interactor interactor)
    {
        Debug.Log(debugString);
    }
}
