using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************
 * File     : StateAlert.cs
 * Purpose  : The state for an enemy seeking the player.
 * Notes    : 
 ******************************************************************************/
//Copyright 2017 Andrew Waugh, Licensed under the terms of the MIT license.
public class StateSeekPlayer : State<Enemy>
{
    private static StateSeekPlayer instance = null;

    public override void Enter(Enemy owner)
    {
        return;
    }

    public override void Execute(Enemy owner)
    {
        //owner.SeekPlayer()
        return;
    }

    public override void Exit(Enemy owner)
    {
        return;
    }

    public static StateSeekPlayer getInstance()
    {
        if (instance == null)
        {
            instance = new StateSeekPlayer();
        }

        return instance;
    }
}
