using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************
 * File     : StateAsleep.cs
 * Purpose  : The state an enemy should be in when out of activation range of
 * the player. It is purposefully very minimal.
 * Notes    : 
 ******************************************************************************/
//Copyright 2017 Andrew Waugh, Licensed under the terms of the MIT license.
public class StateAsleep : State<Enemy>
{
    private static StateAsleep instance = null;
    public override void Enter(Enemy owner)
    {
        return;
    }

    public override void Execute(Enemy owner)
    {
        return;
    }

    public override void Exit(Enemy owner)
    {
        return;
    }

    public static StateAsleep getInstance()
    {
        if (instance == null)
        {
            instance = new StateAsleep();
        }
        return instance;
    }
}
