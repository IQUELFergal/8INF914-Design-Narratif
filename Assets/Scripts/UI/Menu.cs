using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    protected void Open()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    protected void Close()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
