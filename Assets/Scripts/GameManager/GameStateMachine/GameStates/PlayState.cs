using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayState : GameState
{
    public PlayState() : base()
    {

    }

    public override string debugStateName => "Play";

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.InputManager.Inputs.UI.Cancel.performed += OnPauseInput;
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.InputManager.Inputs.UI.Cancel.performed -= OnPauseInput;
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

    void OnPauseInput(InputAction.CallbackContext context)
    {
        GameManager.Instance.StateMachine.ChangeState(GameManager.Instance.MainMenuState);
    }
}
