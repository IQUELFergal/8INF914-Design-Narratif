using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractableState
{
    public string stateName;
    public List<GameObject> stateInteractables;
}

public class MultiStateInteractable : MonoBehaviour, IInteractable
{
    public enum StateChangeOrder { Sequencial, PingPong, Random}
    [SerializeField] StateChangeOrder stateChangeOrder = StateChangeOrder.Sequencial;
    [SerializeField] List<InteractableState> states = new List<InteractableState>();
    public int currentStateIndex = 0;
    public bool pingPongOrder = true;

    public void Interact(Interactor interactor)
    {
        if (states.Count > 0)
        {
            foreach (var gameObject in states[currentStateIndex].stateInteractables)
            {
                IInteractable[] interactables = gameObject.GetComponentsInChildren<IInteractable>();
                foreach (var interactable in interactables)
                {
                    interactable.Interact(interactor);
                }
            }
            GetNextState();
        }
    }

    void GetNextState()
    {
        switch (stateChangeOrder)
        {
            case StateChangeOrder.Sequencial:
                currentStateIndex++;
                if (currentStateIndex >= states.Count)
                {
                    currentStateIndex = 0;
                }
                break;

            case StateChangeOrder.PingPong:
                if (pingPongOrder)
                {
                    currentStateIndex++;
                    if (currentStateIndex >= states.Count - 1)
                    {
                        pingPongOrder = false;
                    }
                }
                else
                {
                    currentStateIndex--;
                    if (currentStateIndex < 1)
                    {
                        pingPongOrder = true;
                    }
                }
                break;

            case StateChangeOrder.Random:
                currentStateIndex = Random.Range(0, states.Count);
                break;

            default:
                break;
        }
    }
}
