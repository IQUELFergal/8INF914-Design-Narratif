using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkPlayerState : PlayerState
{
    public WalkPlayerState(Player player) : base(player)
    {
    }

    protected override string stateName => "Walk";

    public override void Enter()
    {
        base.Enter();
        GameManager.Instance.InputManager.Inputs.Player.Sprint.started += OnSprintDownInput;
        GameManager.Instance.InputManager.Inputs.Player.Interact.performed += player.Interactor.Interact;
        GameManager.Instance.InputManager.Inputs.Player.SwitchInteractable.performed += player.Interactor.SwitchCollider;
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.InputManager.Inputs.Player.Sprint.started -= OnSprintDownInput;
        GameManager.Instance.InputManager.Inputs.Player.Interact.performed -= player.Interactor.Interact;
        GameManager.Instance.InputManager.Inputs.Player.SwitchInteractable.performed -= player.Interactor.SwitchCollider;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        player.MovementManager.Move(moveDir, player.walkSpeed);
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
        if (moveInput.magnitude < 0.05f)
        {
            player.StateMachine.ChangeState(player.IdlePlayerState);
        }
    }

    void OnSprintDownInput(InputAction.CallbackContext context)
    {
        player.StateMachine.ChangeState(player.SprintPlayerState);
    }
}
