using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerState : IState
{
    protected Player player;
    protected float startTime;

    protected Vector2 moveInput;
    protected Vector2 moveDir;

    protected Vector2 lookInput;
    protected Vector2 lookDir;

    protected abstract string stateName { get; }
    public PlayerState(Player player)
    {
        this.player = player;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        player.DebugStateName = stateName;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void Update()
    {
        moveInput = GameManager.Instance.InputManager.Inputs.Player.Move.ReadValue<Vector2>();
        moveDir = moveInput.normalized;

        lookInput = GameManager.Instance.InputManager.Inputs.Player.Look.ReadValue<Vector2>();
        lookDir = lookInput.normalized;
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {
        
    }

}
