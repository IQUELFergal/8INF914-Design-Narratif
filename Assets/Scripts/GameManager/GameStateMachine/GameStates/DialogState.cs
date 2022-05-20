using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogState : GameState
{
    public DialogState() : base()
    {
    }

    public override string debugStateName => "Dialog";

    public override void Enter()
    {
        base.Enter();
        DialogUI.onOpenMenu?.Invoke();

        GameManager.Instance.InputManager.DisablePlayerInputs();
        GameManager.Instance.InputManager.Inputs.UI.Cancel.performed += OnQuitDialogInput;
        GameManager.Instance.InputManager.Inputs.UI.Submit.performed += OnNextDialogInput;
    }

    public override void Exit()
    {
        base.Exit();
        DialogUI.onCloseMenu?.Invoke();

        GameManager.Instance.InputManager.EnablePlayerInputs();
        GameManager.Instance.InputManager.Inputs.UI.Cancel.performed -= OnQuitDialogInput;
        GameManager.Instance.InputManager.Inputs.UI.Submit.performed -= OnNextDialogInput;
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

    void OnQuitDialogInput(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.PlayState);
    }

    void OnNextDialogInput(InputAction.CallbackContext context)
    {
        DialogManager.ProgressDialog();
    }
}
