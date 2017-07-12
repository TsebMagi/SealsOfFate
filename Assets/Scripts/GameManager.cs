using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Level Manager for the Seals of Fate Handles creating the level and
// delegates the room creation 
public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private LevelManager levelScript;
	private int currentLevel = 1;
	public int maxLevel;

	public bool playersTurn = true;

	public int playerFoodPoints;

	// Use this for initialization
	void Awake () {

		// Singleton Code
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		// Grab the currently attached levelManager script
		levelScript = GetComponent<LevelManager>();
		// Setup the level.
		InitLevel();
	}

	public GameManager getInstance(){return instance;}
	void InitLevel(){
		levelScript.SetupScene(currentLevel);
	}

	public void GameOver(){
		
	}
}
