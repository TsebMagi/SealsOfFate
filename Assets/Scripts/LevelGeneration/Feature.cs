using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Utility;
using Random = UnityEngine.Random;
    /// <summary> The Feature Class is the base class for features on the map </summary>
    class Feature
    {

        /// <summary> Represents the relative range of x values in the feature </summary>
        public Range xRange;
        /// <summary> Represents the relative range of y values in the feature </summary>
        public Range yRange;
        public int[,] featureMap;

        /// <summary> stiches a feature into this feature at the given starting point </summary>
        /// <param name="toStitch"> The feature being added to this feature </param>
        /// <param name="startPoint"> Feature will be filled in by being added up and right of the listed point </param>
        public bool StitchFeature(Feature toStitch, Vector2 startPoint) {
            if(featureMap == null){throw new Exception();}
            
            if(toStitch.xRange.max + (int)startPoint.x > xRange.max || toStitch.yRange.max + (int)startPoint.y > yRange.max) {return false;}
            
            for (int x=0; x < toStitch.xRange.max; ++x) {
                for(int y=0; y < toStitch.yRange.max; ++y) { featureMap[x+(int)startPoint.x,y+(int)startPoint.y] = toStitch.featureMap[x,y];}
            }
            return true;
        }

    public int CheckAdjacent(int x, int y){
        int ret = 0;
        if(x > 0 && featureMap[x-1,y] == 1){
            ++ret;
        }
        if(x < featureMap.GetLength(0)-1 && featureMap[x+1,y] == 1){
            ++ret;
        }
        if(y > 0 && featureMap[x,y-1] == 1){
            ++ret;
        }
        if(y < featureMap.GetLength(1)-1 && featureMap[x,y+1] == 1){
            ++ret;
        }
        return ret;
    }
    }