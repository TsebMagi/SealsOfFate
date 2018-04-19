using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
public class AttackBehaviour : MonoBehaviour {

	public Combat.AttackInfo attack;
	public bool destroyAfterCollision;
	// Basic Attach Behaviour
	// Applies the attack to the object hit
	void OnCollisionEnter2D(Collision2D other){
		other.gameObject.SendMessage("RecieveAttack",attack);
		if(destroyAfterCollision){Destroy(this.gameObject);}
	}
}
