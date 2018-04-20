using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Combat{
public class AttackBehaviour : MonoBehaviour {
	/// <summary>
	///		The Attack data represented by this object
	/// </summary>
	public Combat.AttackInfo attack;
	/// <summary>
	///		The amount of time this attack should live on screen
	/// </summary>
	public float timeToLive;
	public bool destroyAfterCollision;
	// Basic Attach Behaviour
	// Applies the attack to the object hit
	void OnCollisionEnter2D(Collision2D other){
		other.gameObject.SendMessage("RecieveAttack",attack);
		if(destroyAfterCollision){Destroy(this.gameObject);}
	}
	void Update(){
		timeToLive -= Time.deltaTime;
		if(timeToLive<=0){Destroy(this.gameObject);}

	}
}
}