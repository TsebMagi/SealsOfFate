using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
class Level : Feature
{
    public int[,] MiniMap;

    /// <summary> Generates a level </summary>
    public void Generate(int MinChunks, int MaxChunks, int ChunkDimension)
    {
        /// <remark> setup the graph </remark>
        var numRooms = Random.Range(MinChunks, MaxChunks);
        /// <remark> size the map to allow for each room take up the maximum and leave space for tunnels </remark>
        xRange.max = yRange.max = (ChunkDimension * numRooms) + 2;
        xRange.min = yRange.min = 0;
        featureMap = new int[xRange.max, yRange.max];
        BuildMiniMap(numRooms);
        BuildChunks(ChunkDimension);
        FillInWalls();
    }

    private void BuildMiniMap(int numRooms)
    {
        List<Vector2> potentialSlots = new List<Vector2>();
        MiniMap = new int[numRooms, numRooms];
        potentialSlots.Add(new Vector2(0,0));
        /// update to adjacent index
        for (int i = 0; i < numRooms; ++i)
        {
            Vector2 toPlace = potentialSlots[Random.Range(0,potentialSlots.Count)];
            potentialSlots.Remove(toPlace);
            if(potentialSlots.Count > 0){
            Vector2 toRemove = potentialSlots[Random.Range(0,potentialSlots.Count)];
                potentialSlots.Remove(toRemove);
            }
            MiniMap[(int)toPlace.x, (int)toPlace.y] = 1;
            if(toPlace.x < MiniMap.GetLength(0)-1 && MiniMap[(int)toPlace.x+1, (int)toPlace.y] !=1){
                potentialSlots.Add(new Vector2(toPlace.x+1,toPlace.y));
            }
            if(toPlace.x > 0 && MiniMap[(int)toPlace.x-1, (int)toPlace.y] !=1){
                potentialSlots.Add(new Vector2(toPlace.x-1,toPlace.y));
            }
            if(toPlace.y < MiniMap.GetLength(0)-1 && MiniMap[(int)toPlace.x, (int)toPlace.y+1] !=1){
                potentialSlots.Add(new Vector2(toPlace.x,toPlace.y+1));
            }
            if(toPlace.y > 0 && MiniMap[(int)toPlace.x, (int)toPlace.y-1] !=1){
                potentialSlots.Add(new Vector2(toPlace.x,toPlace.y-1));
            }
        }
    }

    private void BuildChunks(int ChunkDimension)
    {
        for (int x = 1; x < MiniMap.GetLength(0) - 1; ++x)
        {
            for (int y = 1; y < MiniMap.GetLength(1) - 1; ++y)
            {
                if (MiniMap[x, y] == 1)
                {
                    for (int j = 0; j < ChunkDimension; ++j)
                    {
                        for (int k = 0; k < ChunkDimension; ++k)
                            featureMap[x * ChunkDimension + j, y * ChunkDimension + k] = (int)levelRepresentations.Floor;
                    }
                }
            }
        }
    }

    private void FillInWalls()
    {
        for (int x = 0; x < featureMap.GetLength(0); x++)
        {
            for (int y = 0; y < featureMap.GetLength(1); y++)
            {
                if (featureMap[x, y] == 0 && CheckAdjacent(x, y) > 0)
                {
                    featureMap[x, y] = (int)levelRepresentations.Wall;
                }
            }
        }
    }
}