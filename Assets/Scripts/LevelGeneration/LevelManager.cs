using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

/// <summary> enum abstraction of each tile that could be places on the board </summary>
public enum levelRepresentations { NOTHING, Floor, Wall, Door, Enemy, Loot, Obstacles, Start, Exit, TOTAL }

/// <summary> The levelManager Class handles the level generation for each level </summary>
public class LevelManager : MonoBehaviour
{
    /// <summary> Collection of Walls to be used for generating the level </summary>
    public GameObject[] Walls;
    /// <summary> Collection of Floors to be used for generating the level </summary>
	public GameObject[] Floors;
    /// <summary> Collection of Enemies to be used for generating the level </summary>
    public GameObject[] Enemies;
    /// <summary> Collection of Loot to be used for generating the level </summary>
    public GameObject[] Loot;
    /// <summary> Collection of Doors to be used for generating the level </summary>
    public GameObject[] Doors;
    /// <summary> Collection of Obstacles to be used for generating the level </summary>
    public GameObject[] Obstacles;
    /// <summary> Maximum number of rooms to generate </summary>
    public int MaxChunks;
    /// <summary> Minimum number of rooms to generate </summary>
    public int MinChunks;
    /// <summary> Chunk size to generate </summary>
    public int ChunkSize;

    /// <summary> The Board that is being created </summary>
    private Transform boardHolder;
    /// <summary> List of Positions in the Grid </summary>
    private int[,] gridPositions;
    /// <summary> The level that will be created </summary>
    private Level currentLevel;

    /// <summary> sets up the level </summary>
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;
        /// create and setup the level
        currentLevel = new Level();
        currentLevel.Generate(MinChunks, MaxChunks, ChunkSize);
        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < currentLevel.xRange.max; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < currentLevel.yRange.max; y++)
            {
                //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = null;

                if (currentLevel.featureMap[x,y] == (int)levelRepresentations.Floor)
                    toInstantiate = Floors[Random.Range(0, Floors.Length)];
                //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                if (currentLevel.featureMap[x,y] == (int)levelRepresentations.Wall)
                    toInstantiate = Walls[Random.Range(0, Walls.Length)];

                if(toInstantiate){
                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance =
                    Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity) as GameObject;
                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardHolder);
                }
            }
        }
    }

    /// <summary> Entry Point for level creation. Sets up the board </summary>
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.SetPositionAndRotation(new Vector2(ChunkSize+(ChunkSize/2), ChunkSize+(ChunkSize/2)),Quaternion.identity);
    }

}





