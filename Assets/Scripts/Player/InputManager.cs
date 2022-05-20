using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputManager : MonoBehaviour
{
    PlayerInputs inputs;

    public PlayerInputs Inputs { get => inputs; private set => inputs = value; }

    void Awake()
    {
        inputs = new PlayerInputs();
    }

    void OnEnable()
    {
        EnableAllInputs();
    }

    void OnDisable()
    {
        DisableAllInputs();
    }

    public void EnableAllInputs()
    {
        Debug.Log("Inputs enabled.");
        inputs.Enable();
    }

    public void DisableAllInputs()
    {
        Debug.Log("Inputs disabled.");
        inputs.Disable();
    }

    public void EnablePlayerInputs()
    {
        Debug.Log("Player inputs enabled.");
        inputs.Player.Enable();
    }

    public void DisablePlayerInputs()
    {
        Debug.Log("Player inputs disabled.");
        inputs.Player.Disable();
    }

    public void EnableUIInputs()
    {
        Debug.Log("UI inputs enabled.");
        inputs.UI.Enable();
    }

    public void DisableUIInputs()
    {
        Debug.Log("UI inputs disabled.");
        inputs.UI.Disable();
    }

}
