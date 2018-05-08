using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Combat{
public class RangedAttack : AttackStats {
	// Applies the attack to the object hit
	RangedAttack(AttackType Type, int Damage, DamageType[] Damagetypes, float ForceToApply, string Description) :base(Type,Damage,Damagetypes,ForceToApply,Description){

	}
	void OnCollisionEnter2D(Collision2D other){
		other.gameObject.SendMessage("RecieveAttack", this,options:SendMessageOptions.DontRequireReceiver);
		if(destroyAfterCollision == true){Destroy(this.gameObject);}
	}
	public override void Update(){
		timeToLive -= Time.deltaTime;
		if(timeToLive<=0){Destroy(this.gameObject);}
		else{
			this.GetComponent<Rigidbody2D>().velocity = TargetVector * moveSpeed;
		}

	}
        /// <summary>The amount of time this attack should live on screen </summary>
		[SerializeField]
        private float timeToLive;
        /// <summary>Controls if the projectile is removed after a colision </summary>
		[SerializeField]
        private bool destroyAfterCollision;
        /// <summary>Movement speed of the projectile </summary>
		[SerializeField]
        private float moveSpeed;
		/// <summary>Track the Target? </summary>
		private bool tracking;
        public float TimeToLive { get{return timeToLive;} set{timeToLive=value;} }
        public bool DestroyAfterCollision { get{return destroyAfterCollision;} set{destroyAfterCollision = value;} }
        public float MoveSpeed { get{return moveSpeed;} set{moveSpeed=value;} }
        public bool Tracking { get{return tracking;} set{tracking=value;} }
    }
}