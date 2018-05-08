using System.Collections.Generic;
using Assets.Scripts.LevelGeneration;
using UnityEngine;
using UnityEngine.SceneManagement;
//TODO: cleanup and comment Game Manager

// Level Manager for the Seals of Fate Handles creating the level and
// delegates the room creation 
namespace Assets.Scripts{
    public class GameManager : MonoBehaviour{
        public static GameManager instance;
        private readonly int currentLevel = 1;
        public int maxLevel;
        public int playerHealth;
        public GameObject player;
        public GameManager(){
        }
        public LevelManager levelScript { get; set; }
        /// <summary>
        ///     Initializes the GameManager
        /// </summary>
        private void Awake(){
            // Singleton Code
            if (instance == null){
                instance = this;
            }
            else if (instance != this){
                Destroy(gameObject);
            }
            Instantiate(player,new Vector2(0,0),Quaternion.identity);
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(player);
            // Grab the currently attached levelManager script
            levelScript = GetComponent<LevelManager>();
            InitLevel();
        }

        /// <summary>Get the CurrentLevelFeatureMap</summary>
        internal static int[,] CurrentLevelFeatureMap{
            get { return instance.levelScript.CurrentLevel.FeatureMap; }
        }

        /// <summary> 
        ///     Handles returning the game control to player and running other entities
        /// </summary>
        private void Update() { }
        /// <summary>
        ///     Returns an instance of the GameManager
        /// </summary>
        /// <returns></returns>
        public static GameManager GetInstance(){
            return instance;
        }
        /// <summary>
        ///     Sets up the level
        /// </summary>
        private void InitLevel(){
            levelScript.SetupScene(currentLevel);
        }
        /// <summary>
        ///     Something, something, end of the game.
        /// </summary>
        public void GameOver(){
            SceneManager.LoadScene("GameOver");
        }
    }
}