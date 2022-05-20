using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState : IState
{

    protected GameState()
    {
    }

    public abstract string debugStateName { get; }

    public virtual void Enter()
    {
        GameManager.Instance.currentState = debugStateName;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {
        
    }

    public virtual void Update()
    {
        
    }
}
