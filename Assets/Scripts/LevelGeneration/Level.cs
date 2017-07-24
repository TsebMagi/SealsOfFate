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
        fillInWalls();
    }

    IEnumerable BuildMiniMap(int numRooms)
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
                int newX = Random.Range(-1, 1);
                int newY = Random.Range(-1, 1);
                if (curX + newX > 0 && curX + newX < MiniMap.Length)
                {
                    if (curY + newY > 0 && curY + newY < MiniMap.Length)
                    {
                        done = true;
                        curX += newX;
                        curY += newY;
                    }
                }
                else{
                    yield return null;
                }
            }
        }
    }

    void BuildChunks(int ChunkDimension)
    {
        for (int x = 1; x < featureMap.Length - 1; ++x)
        {
            for (int y = 1; y < featureMap.Length - 1; ++y)
            {
                if (MiniMap[(int)(x / ChunkDimension), (int)(y / ChunkDimension)] == 1)
                {
                    featureMap[x, y] = (int)levelRepresentations.Floor;
                }
            }
        }
    }

    void fillInWalls()
    {
        for (int x = 0; x < featureMap.Length; x++)
        {
            for (int y = 0; y < featureMap.Length; y++)
            {
                if (featureMap[x, y] == 0 && CheckAdjacent(x, y) > 0)
                {
                    featureMap[x, y] = (int)levelRepresentations.Wall;
                }
            }
        }
    }
}