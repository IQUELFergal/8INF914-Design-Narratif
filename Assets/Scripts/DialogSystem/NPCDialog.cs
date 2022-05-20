using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] Dialog dialog;

    public void Talk()
    {
        DialogManager.OpenDialog(dialog);
    }
}

