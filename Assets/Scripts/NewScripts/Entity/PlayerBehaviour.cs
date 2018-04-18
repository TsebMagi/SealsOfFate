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
    /// <summary>Stores the Player's Movement Speed.</summary>
    private ushort _movementSpeed;

    public PlayerBehaviour() {
        
        // TODO populate me
        //_combatData = new CombatData {
        //    HealthPoints = 100,
        //    ManaPoints = 10,
        //    SealieAttack = new AttackInfo(10, DamageType.Blunt, "A vicious nose boop")
        //};
    }
    private void OnDestroy() {
        Debug.Log("Player Destroyed");
    }

    public override void Update() {

    }

    /// <summary>
    ///     Attempts to move the Player in the direction specified by xDir and yDir. This method will
    /// </summary>
    /// <param name="xDir">The horizontal direction (left or right).</param>
    /// <param name="yDir">The vertical direction (up or down).</param>
    /// <param name="T">
    ///     An obstruction, such as an enemy or a wall, that could possibly
    ///     prohibit movement.
    /// </param>

    /// <summary>
    ///     Handles collision logic and determines how the Player interaction with
    ///     other with other GameObjects on collision are invoked.
    /// </summary>
    /// <param name="other">
    ///     A reference to the GameObject's collider that the
    ///     Player collided into.
    /// </param>
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
        }
    }

    /// <summary>
    ///
    /// </summary>
    private void CheckIfGameOver() {
    }
}