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
        MiniMap = new int[numRooms, numRooms];
        int curX = 0;
        int curY = 0;
        /// update to adjacent index
        for (int i = 0; i < numRooms; ++i)
        {
            MiniMap[curX,curY] = 1;
            bool done = false;
            while (!done)
            {
                int newX = Random.Range(-1, 2);
                int newY = Random.Range(-1, 2);
                if (curX + newX > 0 && curX + newX < MiniMap.GetLength(0))
                {
                    if (curY + newY > 0 && curY + newY < MiniMap.GetLength(0))
                    {
                        done = true;
                        curX += newX;
                        curY += newY;
                    }
                }
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
                    for(int j = 0; j < ChunkDimension; ++j){
                        for(int k = 0; k < ChunkDimension; ++k)
                        featureMap[x*ChunkDimension+j, y*ChunkDimension+k] = (int)levelRepresentations.Floor;
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