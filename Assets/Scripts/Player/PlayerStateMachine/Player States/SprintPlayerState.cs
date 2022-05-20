using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprintPlayerState : PlayerState
{
    public SprintPlayerState(Player player) : base(player)
    {
    }

    protected override string stateName => "Run";

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.InputManager.Inputs.Player.Sprint.canceled += OnSprintUpInput;
        player.AnimationManager.SetRunning(true);
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.InputManager.Inputs.Player.Sprint.canceled -= OnSprintUpInput;
        player.AnimationManager.SetRunning(false);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        player.MovementManager.Move(moveDir, player.sprintSpeed);
    }

    public override void Update()
    {
        base.Update();
        if (moveInput.magnitude > 0.05f)
        {
            player.AnimationManager.SetDirection(moveDir);
            player.AnimationManager.SetSpeed(player.walkSpeed);
            player.Interactor.SetOffset(moveDir);
        }
        else
        {
            player.StateMachine.ChangeState(player.IdlePlayerState);
        }
    }

    void OnSprintUpInput(InputAction.CallbackContext context)
    {
        player.StateMachine.ChangeState(player.WalkPlayerState);
    }
}
