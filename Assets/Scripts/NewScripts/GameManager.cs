using System.Collections.Generic;
using Assets.Scripts.LevelGeneration;
using UnityEngine;
using UnityEngine.SceneManagement;


// Level Manager for the Seals of Fate Handles creating the level and
// delegates the room creation 
namespace Assets.Scripts{
    public class GameManager : MonoBehaviour{
        private static float MinimumDistanceFromPlayer = 200f;
        public static GameManager Instance;
        private readonly int currentLevel = 1;
        public int MaxLevel;
        public int PlayerHealth;
        public GameManager(){
        }
        public LevelManager LevelScript { get; set; }
        /// <summary>
        ///     Initializes the GameManager
        /// </summary>
        private void Awake(){
            // Singleton Code
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            // Grab the currently attached levelManager script
            LevelScript = GetComponent<LevelManager>();
            InitLevel();
        }

        /// <summary>Get the CurrentLevelFeatureMap</summary>
        internal static int[,] CurrentLevelFeatureMap{
            get { return Instance.LevelScript.CurrentLevel.FeatureMap; }
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
            return Instance;
        }
        /// <summary>
        ///     Sets up the level
        /// </summary>
        private void InitLevel(){
            LevelScript.SetupScene(currentLevel);
        }
        /// <summary>
        ///     Something, something, end of the game.
        /// </summary>
        public void GameOver(){
            SceneManager.LoadScene("GameOver");
        }
    }
}