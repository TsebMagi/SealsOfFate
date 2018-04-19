using System;
using Assets.Scripts;
using Combat;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///     This class contains logic for processing player input and interacting with other relevant
///     GameObjects in the generated scene.
/// </summary>
public class PlayerBehaviour : EntityBehaviour {
    /// <summary>
    ///     Used for initialization
    /// </summary>
    public override void Start(){
        base.Start();
    }
    /// <summary>
    ///     Handles logging end of game, and calls to end of game
    ///     TODO add call to end game
    /// </summary>
    private void OnDestroy() {
        Debug.Log("Player Destroyed");
    }
    /// <summary>
    ///     Handles player movement
    /// </summary>
    void FixedUpdate() {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rgb2d.AddForce(movement * moveSpeed);
    }
    /// <summary>
    ///     Handles player input other than movement
    /// </summary>
    public override void Update(){
        base.Update();
    }
    /// <summary>
    ///     Handles how the player should interact with different collisions
    /// </summary>
    /// <param name="other">Object that was collided with by this player entity</param>
    private void OnTriggerEnter2D(Collider2D other) {
        // Check if the tag of the trigger collided with is Exit.
        switch (other.tag) {
            case "Exit":
                Debug.Log("Exit Hit");
                // Disable the player object since level is over.
                enabled = false;
                break;
            case "Pick Up":
                // Disable the food object the player collided with.
                Debug.Log("The Pick Up has been encountered!");
                other.gameObject.SetActive(false);
                var food = other.gameObject.GetComponent<Food>();
                food.Consume();
                break;
            case "Wall":
                Debug.Log("Wall Hit");
                break;
            default:
                Debug.Log("The Seal Has hit a(n) "+ other.tag + "!");
                break;
        }
    }
}