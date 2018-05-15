using System;
using Assets.Scripts;
using Combat;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Entity{
/// <summary>
///     This class contains logic for processing player input and interacting with other relevant
///     GameObjects in the generated scene.
/// </summary>
public class PlayerBehaviour : EntityBehaviour {
    public override void Start(){
        base.Start();
    }
    /// <summary>Handles logging end of game, and calls to end of game </summary>
    ///TODO add call to end game
    private void OnDestroy() {
        Debug.Log("Player Destroyed");
    }
    /// <summary>Handles how the player should interact with different collisions </summary>
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
                var pickUp = other.gameObject.GetComponent<IInteractable>();
                pickUp.Interact();
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
}