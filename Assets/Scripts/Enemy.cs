using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    private StateMachine<Enemy> stateMachine;

    public StateMachine<Enemy> getStateMachine()
    {
        return stateMachine;
    }
    protected override void OnCantMove<T>(T component)
    {
        throw new NotImplementedException();
    }

}
