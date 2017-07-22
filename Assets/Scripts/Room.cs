using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

    /// <summary> This Class extends the Feature Class by adding information specifically for the rooms </summary>
    class Room : Feature
    {
        /// <summary> doorway represents the entrance to the room created during map generation </summary>
        public Vector2 doorway;
        /// <summary> exits represents the exits of thise room, they can becom doorways to other rooms </summary>
        public Vector2 [] exits;

        /// <summary> containedFeatrues is the list of features that room contains </summary>
        private List <Feature> containedFeatures;
        /// <summary> generates a room and handles filling it with features </summary>

        /// <summary> Constructor, Will make the rooms internal ranges relative, but can be passed relative or absolute ranges </summary>
        public Room(Range xRange, Range yRange) : base(xRange,yRange){}
        public override void generate(Range xRange, Range yRange, levelRepresentations[] validToPlace) 
        {
            for(int x = xRange.min; x < xRange.max; ++x)
            {
                for(int y = yRange.min; y < yRange.max; ++y)
                {
                    featureMap[x,y] = (int)levelRepresentations.Floor;
                }
            }
        }
    }