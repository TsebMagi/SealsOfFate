using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Level Manager for the Seals of Fate Handles creating the level and
// delegates the room creation 
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private LevelManager levelScript;


	// Use this for initialization
	void Awake () {

		// Singleton
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
