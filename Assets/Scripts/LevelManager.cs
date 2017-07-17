using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

/// <summary> The levelManager Class handles the level generation for each level </summary>
public class LevelManager : MonoBehaviour
{
   
    /// <summary> Number of Columns in the grid that the map will be generated on </summary>
    public int columns;
    /// <summary> Number of Row in the grid that the map will be generated on </summary>
    public int rows;
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

    /// <summary> Class that contains the stats for a room </summary>
    private class RoomStats
    {
        public Range xRange;
        public Range yRange;
        public Vector2 doorway;
        public Vector2 [] exits;
    }

    /// <summary> The Board that is being created </summary>
    private Transform boardHolder;
    /// <summary> List of Positions in the Grid </summary>
    private int[,] gridPositions;
    /// <summary> Queue used for room creation </summary>
    private Queue roomsToBuild;

    /// <summary> Creates a list of coordinates that can be used for level generation </summary>
    void InitialiseList()
    {
        /// clears our list gridPositions.
        gridPositions = new int [columns, rows];

        //Loop through x axis (columns).
        for (int x = 1; x < columns - 1; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 1; y < rows - 1; y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                gridPositions[x, y] = 0;
            }
        }
    }

    /// <summary> sets up the level </summary>
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = -1; x < columns + 1; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = -1; y < rows + 1; y++)
            {
                //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = Floors[Random.Range(0, Floors.Length)];

                //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = Walls[Random.Range(0, Walls.Length)];

                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance =
                    Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity) as GameObject;

                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardHolder);
            }
        }
    }
    /// <summary> Creates a room in the boundaries given </summary>
    void SetupRoom(Vector2 start, Vector2 stop)
    {

    }

    /// <summary> Entry Point for level creation. Sets up the board </summary>
    public void SetupScene(int level)
    {
        //Creates the outer walls and floor.
        BoardSetup();

        //Reset our list of gridpositions.
        InitialiseList();

        //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
        //LayoutObjectAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);

        //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
        //LayoutObjectAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);

        //Determine number of enemies based on current level number, based on a logarithmic progression
        //int enemyCount = (int)Mathf.Log(level, 2f);
        int enemyCount = 2;
        //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
        //LayoutObjectAtRandom(Enemies, enemyCount, enemyCount);

        //Instantiate the exit tile in the upper right hand corner of our game board
        //Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}





