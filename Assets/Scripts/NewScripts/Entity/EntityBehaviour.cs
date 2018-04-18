using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class used to wrap Entity Data up together
public abstract class EntityBehaviour : MonoBehaviour {
    public int _maxHealth;
    public int currentHealth;
    public int _maxMana;
    public int currentMana;
    private bool alive;
    public int xp;
    public float moveSpeed;
    public Combat.CombatData combatData;
    public RectTransform healthBar;
    private Animator _animator;	
    public void Start () {
        currentHealth = _maxHealth;
        currentMana = _maxMana;
        alive = true;
	}
    /// <summary>
    /// Used by attacker when entity is attacked, to calculate Damage taken by this entity
    /// </summary>
    /// <param name="AttackerCD"> The attacking entities Combat Data </param>
    public void RecieveAttack(Combat.CombatData AttackerCD){
        Combat.CombatResult cBResult = Combat.CombatData.ComputeDamage(AttackerCD.ToTemporaryCombatData(), combatData.ToTemporaryCombatData());
        this.currentHealth += cBResult.DefenderDamage.HealthDamage;
        this.currentMana += cBResult.DefenderDamage.ManaDamage;
        if(this.currentHealth <= 0){
            alive = false;
        }
    }

    public virtual void Update(){
        if(!alive){
            Destroy(this.gameObject);
            // TODO apply Experience to player
        }
    }
}