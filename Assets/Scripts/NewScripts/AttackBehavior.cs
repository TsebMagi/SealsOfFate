using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;

public class Attack : MonoBehaviour {

	public Combat.CombatData AttackData;
	public bool destroyAfterCollision;
	// Use this for initialization
	void Start () {
		this.AttackData = GetComponentInParent<CombatData>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// Basic Attach Behaviour
	// Applies the attack to the object hit
	void OnTriggerEnter(Collider other){
		// TODO add damaging code
	}
}
