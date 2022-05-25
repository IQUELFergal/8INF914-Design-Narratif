using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuState : GameState
{
    public MainMenuState() : base()
    {
    }

    public override string debugStateName => "MainMenu";

    public override void Enter()
    {
        base.Enter();

        MainMenu.onOpenMenu?.Invoke();
        GameManager.Instance.InputManager.DisablePlayerInputs();
        GameManager.Instance.InputManager.Inputs.UI.Cancel.performed += OnPlayInput;
    }

    public override void Exit()
    {
        base.Exit();

        MainMenu.onCloseMenu?.Invoke();
        GameManager.Instance.InputManager.EnablePlayerInputs();
        GameManager.Instance.InputManager.Inputs.UI.Cancel.performed -= OnPlayInput;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void Update()
    {
        base.Update();
    }

    void OnPlayInput(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.PlayState);
    }
}
