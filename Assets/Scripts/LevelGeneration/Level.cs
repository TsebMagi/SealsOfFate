using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

class Level : Feature {
    public Graph<Vector2> LevelLayout;
    public int [,] MiniMap;

    public Level(Range xRange, Range yRange): base(xRange, yRange){}


    void Generate(int MinRooms, int MaxRooms, int MaxDimension, int MinDimension){
        /// <remark> setup the graph </remark>
        var numRooms = Random.Range(MinRooms, MaxRooms);
        /// <remark> size the map to allow for each room take up the maximum and leave space for tunnels </remark>
        featureMap = new int[MaxDimension*numRooms*2,MaxDimension*numRooms*2];
        /// <remark> Queue used for room creation </remark>
        Queue roomsToBuild = new Queue();
        /// Generate a random set of rooms
        for(int i =0; i < numRooms; ++i) {
            roomsToBuild.Enqueue(new Room(new Range((Random.Range(MinDimension,MaxDimension))),new Range((Random.Range(MinDimension,MaxDimension)))));
        }
    }

    void buildGraph(int numRooms){
        LevelLayout = new Graph<Vector2>(numRooms);
        
        int[,] MiniMap = new int[numRooms*2,numRooms*2];
        while(numRooms > 0){
            int x = Random.Range(0,numRooms*2);
            int y = Random.Range(0,numRooms*2);
            if(MiniMap[x,y] == 0) {
                MiniMap[x,y] = 1;
                --numRooms;
            }
        }

        for(int x=1; x < numRooms*2-1; ++x){
            for(int y=1; y < numRooms*2-1; ++y){
            }
        }
    }
}