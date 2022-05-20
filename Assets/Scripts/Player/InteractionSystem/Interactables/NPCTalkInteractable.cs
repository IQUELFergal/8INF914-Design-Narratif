using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCDialog))]
public class NPCTalkInteractable : MonoBehaviour, IInteractable
{
    NPCDialog npcDialog;

    private void Start()
    {
        npcDialog = GetComponent<NPCDialog>();
    }

    public void Interact(Interactor interactor)
    {
        npcDialog.Talk();
    }
}
