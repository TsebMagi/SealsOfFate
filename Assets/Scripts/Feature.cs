using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
    /// <summary> The Feature Class is the base class for features on the map </summary>
    class Feature
    {

        /// <summary> Represents the relative range of x values in the feature </summary>
        public Range xRange;
        /// <summary> Represents the relative range of y values in the feature </summary>
        public Range yRange;
        public int[,] featureMap;

        /// <summary> Constructor, Will make the features internal ranges relative, but can be passed relative or absolute ranges </summary>
        public Feature(Range xRange, Range yRange)
        {
            this.xRange.min = 0;
            this.xRange.max = xRange.max - xRange.min;
            this.yRange.min = 0;
            this.yRange.max = yRange.max - yRange.min;
            featureMap = new int[this.xRange.max, this.yRange.max];
        }
        /// <summary> generates a feature and populates it with items in the validToPlace array </summary>
        public virtual void generate(Range xRange, Range yRange, levelRepresentations[] validToPlace)
        {

        }
    }