using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRaiserInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent eventToRaise;
    public void Interact(Interactor interactor)
    {
        eventToRaise?.Invoke();
    }
}
