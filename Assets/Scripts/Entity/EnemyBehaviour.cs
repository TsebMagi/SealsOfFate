using Assets.Scripts;
using Combat;
using UnityEngine;
namespace Entity{
/// <summary>
///     This class is the general enemy class. It extends Entity and is expected to be extended by more specific
///     classes for particular enemy behavior. It defines general functions that most enemies will need.
/// </summary>
public class EnemyBehaviour : EntityBehaviour{
    /// <summary>The maximum range for an enemy. Enemies will try to stay below this range </summary>
    public float maxRange;
    /// <summary>The minimum range for an enemy. Enemies will try to stay above this range </summary>
    public float minRange;
    /// <summary>How close the player can get before the enemy wakes up </summary>
    public float awakeDistance;
    /// <summary>Reference to the Player Object </summary>
    public float sleepDistance;
    /// <summary>Frequency of attack in seconds </summary>
    public float attackSpeed;
    /// <summary>Internal timer to launch attacks </summary>
    private float attackTimer;
    private GameObject player;
    /// <summary>Wether the enemy is awake </summary>
    private bool _awake;
    /// <summary>Kicks off baseclass start and find the player </summary>
    public override void Start(){
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    /// <summary>checks distance to player and wakes up or sleeps depending on that distance </summary>
    public void Update(){
        attackTimer -= Time.deltaTime;
        if(attackTimer <=0 && _awake){
            CreateRangedAttack((player.transform.position-this.transform.position));
            attackTimer = attackSpeed;
        }
    }
    /// <summary>Moves the Enemy based on preferences </summary>
    void FixedUpdate(){
        var distToPlayer = Vector2.Distance(player.transform.position, transform.position);
        if(!_awake){
            if(distToPlayer < awakeDistance) {_awake = true;}
        }
        else{
            var toPlayer = player.transform.position - transform.position;
            if(distToPlayer > sleepDistance) {_awake = false;}
            else if(distToPlayer < minRange){rgb2d.AddForce((toPlayer).normalized*moveSpeed*-1);}
            else if(distToPlayer >maxRange){rgb2d.AddForce((toPlayer).normalized*moveSpeed);}
        }
    }
}
}