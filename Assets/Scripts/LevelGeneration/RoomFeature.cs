using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.LevelGeneration;
using Utility;
using Random = UnityEngine.Random;


class RoomFeature : Feature
{
    /// <summary> generates a feature and populates it with items in the validToPlace array </summary>    
    public virtual void generate(Range xRange, Range yRange, LevelDecoration[] validToPlace)
    {

    }
}