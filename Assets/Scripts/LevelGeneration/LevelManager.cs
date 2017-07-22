using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

/// <summary> enum abstraction of each tile that could be places on the board </summary>
public enum levelRepresentations { Floor = 1, Wall, Door, Enemy, Loot, Obstacles, Start, Exit }

/// <summary> The levelManager Class handles the level generation for each level </summary>
public class LevelManager : MonoBehaviour
{
    /// <summary> Number of Columns in the grid that the map will be generated on </summary>
    public int Columns;
    /// <summary> Number of Row in the grid that the map will be generated on </summary>
    public int Rows;
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
    public int MaxRooms;
    /// <summary> Minimum number of rooms to generate </summary>
    public int MinRooms;
    /// <summary> Maximum Dimension of rooms to generate </summary>
    public int MaxDimension;
    /// <summary> Minimum Dimension of rooms to generate </summary>
    public int MinDimension;

    /// <summary> The Board that is being created </summary>
    private Transform boardHolder;
    /// <summary> List of Positions in the Grid </summary>
    private int[,] gridPositions;
    /// <summary> Graph of the Level </summary>
    private Graph<Room> levelLayout;

    /// <summary> Creates a list of coordinates that can be used for level generation </summary>
    void InitialiseList()
    {
        /// clears our list gridPositions.
        gridPositions = new int[Columns, Rows];
        //Loop through x axis (columns).
        for (int x = 1; x < Columns - 1; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 1; y < Rows - 1; y++)
            {
                gridPositions[x, y] = 0;
            }
        }
    }

    /// <summary> sets up the level </summary>
    void BoardSetup()
    {
        /// <remark> setup the graph </remark>
        var numRooms = Random.Range(MinRooms, MaxRooms);
        levelLayout = new Graph<Room>(numRooms);
        /// <summary> Queue used for room creation </summary>
        Queue roomsToBuild = new Queue();
        for(int i =0; i < numRooms; ++i){
            roomsToBuild.Enqueue(new Room(new Range((Random.Range(0,MaxDimension))),new Range((Random.Range(0,MaxDimension)))));
        }
        Queue openConnections = new Queue();

        Room toPlace = (Room)roomsToBuild.Dequeue();


        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = -1; x < Columns + 1; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = -1; y < Rows + 1; y++)
            {
                //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = Floors[Random.Range(0, Floors.Length)];

                //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                if (x == -1 || x == Columns || y == -1 || y == Rows)
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
    }
}





