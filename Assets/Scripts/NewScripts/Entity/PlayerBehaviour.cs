﻿using System;
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
    public override void Start(){
        base.Start();
    }
    private void OnDestroy() {
        Debug.Log("Player Destroyed");
    }

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
    private void OnTriggerEnter2D(Collider2D other) {
        // Check if the tag of the trigger collided with is Exit.
        switch (other.tag) {
            case "Exit":
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
                rgb2d.velocity = -1*rgb2d.velocity;
                break;
            default:
                Debug.Log("The Seal Has hit something!");
                break;
        }
    }

    /// <summary>
    ///
    /// </summary>
    private void CheckIfGameOver() {
    }
}