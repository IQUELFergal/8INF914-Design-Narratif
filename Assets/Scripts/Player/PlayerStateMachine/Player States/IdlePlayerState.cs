using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public IdlePlayerState(Player player) : base(player)
    {
    }

    protected override string stateName => "Idle";

    public override void Enter()
    {
        base.Enter();
        player.MovementManager.Stop();

        player.AnimationManager.SetSpeed(0);

        GameManager.Instance.InputManager.Inputs.Player.Interact.performed += player.Interactor.Interact;
        GameManager.Instance.InputManager.Inputs.Player.SwitchInteractable.performed += player.Interactor.SwitchCollider;
    }

    public override void Exit()
    {
        base.Exit();
        GameManager.Instance.InputManager.Inputs.Player.Interact.performed -= player.Interactor.Interact;
        GameManager.Instance.InputManager.Inputs.Player.SwitchInteractable.performed -= player.Interactor.SwitchCollider;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void Update()
    {
        base.Update();
        if (moveInput.magnitude > 0.05f)
        {
            player.StateMachine.ChangeState(player.WalkPlayerState);
        }
    }
}
