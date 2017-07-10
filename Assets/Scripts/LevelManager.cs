using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System;

public class LevelManager : MonoBehaviour {
	public class Range{
		public int min;
		public int max;

		Range(int min, int max){
			this.min = min;
			this.max = max;
		}
	}

	public GameObject [][] Walls;
	public GameObject [][] Enemies;
	public GameObject [][] Loot;
	public GameObject [][] Doors;
	public GameObject [][] Obstacles;


  	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
