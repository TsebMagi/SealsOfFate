using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


class RoomFeature : Feature
{

    public RoomFeature(Range xRange, Range yRange) : base(xRange, yRange) { }


    /// <summary> generates a feature and populates it with items in the validToPlace array </summary>    
    public virtual void generate(Range xRange, Range yRange, levelRepresentations[] validToPlace)
    {

    }
}