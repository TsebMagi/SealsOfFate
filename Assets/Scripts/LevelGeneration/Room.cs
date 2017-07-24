using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utility;
using Random = UnityEngine.Random;

    /// <summary> This Class extends the Feature Class by adding information specifically for the rooms </summary>
    class Room : Feature
    {
        /// <summary> exits represents the exits of thise room, they can become doorways to other rooms </summary>
        public Vector2 [] doors;
        /// <summary> containedFeatrues is the list of features that room contains </summary>
        private List <RoomFeature> containedFeatures;

        /// <summary> generates a room and handles filling it with features </summary>
        public void generate(Range xRange, Range yRange, levelRepresentations[] validToPlace, Vector2[] doors) {
            for(int x = 0; x < this.xRange.max; ++x) {
                for(int y = 0; y < this.yRange.max; ++y) {
                    if(y==0 || x==0 || y==yRange.max-1 || x==xRange.max-1) {
                        featureMap[x,y] = (int)levelRepresentations.Wall;
                    }
                    featureMap[x,y] = (int)levelRepresentations.Floor;
                }
            }
            foreach (var v in doors) {
                featureMap[(int)v.x -xRange.min, (int)v.y-yRange.min] = (int)levelRepresentations.Floor;
            }
        }
    }