using Assets.Scripts;
using Combat;
using UnityEngine;

/// <summary>
///     This class is the general enemy class. It extends MovingObject and is expected to be extended by more specific
///     classes for particular enemy behavior. It defines general functions that most enemies will need.
/// </summary>
public class EnemyBehaviour : EntityBehaviour{
    /// <summary> The state machine that handles state transitions. </summary>
    /// <summary> The maximum attack range for an enemy. Enemies will try to stay below this range </summary>
    public int MaxRange;
    /// <summary> The minimum attack range for an enemy. Enemies will try to stay above this range</summary>
    public int MinRange;
    /// <summary>The normal movement speed of the enemy</summary>
    public int Speed;
    private GameObject player;
    private bool awake;
    /// <summary>
    ///     Kicks off baseclass start
    /// </summary>
    public override void Start(){
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Update(){
        base.Update();
        if(Vector2.Distance(player.transform.position, transform.position) < 5){
            awake = true;
        }
        else{
            awake = false;
        }
    }
    void FixedUpdate(){
        if(rgb2d != null && awake == true){
            rgb2d.AddForce((player.transform.position - transform.position).normalized* moveSpeed);
        }
    }
}