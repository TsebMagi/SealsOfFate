using System;
using UnityEngine;

namespace Combat {
    //TODO: Implement drop down selection for Damage Types
    [Serializable]
    public enum DamageType {
        Blunt,
        Slashing,
        Piercing,
        Fire,
        Cold,
        Mana
    }
    [Serializable]
    public enum AttackType{
        Sealie,
        Unsealie,
    }

    [Serializable]
    public class AttackStats : MonoBehaviour{
        /// <summary>
        ///     Creates a new Attack
        /// </summary>
        /// <param name="Type">The type of attack</summary>
        /// <param name="Damage">The amount of pain to inflict</param>
        /// <param name="DamageType">The manner in which it is inflicted</param>
        /// <param name="ForceToApply">The amount of force this attack inflicts</param>
        /// <param name="Description">A human readable description (such as "laserjet printer")</param>
        public AttackStats(AttackType Type, int Damage, DamageType[] DamageType, float ForceToApply ,string Description) {
            type = Type;
            damage = Damage;
            damageType = DamageType;
            description = Description;
            forceToApply = ForceToApply;
        }

        public virtual void Update(){}
        //TODO: Implement special effect system
        public virtual void SpecialEffect(){return;}
        /// <summary>Type of attack Seelie, or Unsealie </summary>
        [SerializeField]
        private AttackType type;
        /// <summary>The damage done by this Attack </summary>
        [SerializeField]
        private int damage;
        /// <summary>The types of damage done by this Attack </summary>
        [SerializeField]
        private DamageType[] damageType;
        /// <summary>A description of the Attack (e.g. sword, tentacle, burning fart) </summary>
        [SerializeField]
        private string description;
        /// <summary>The amount of force this attack applies </summary>
        [SerializeField]
        private float forceToApply;
        /// <summary>Does the Attack cause friendly fire? </summary>
        [SerializeField]
        private bool friendlyFire;
        /// <summary>Vector to move toward for Ranged Attacks and Vector to calculate from for Melee Attacks </summary>
        private Vector2 targetVector;
        public int Damage { get{return damage;} set{damage = value;} }
        public DamageType[] DamageType { get{return damageType;} set{damageType=value;} }
        public string Description { get{return description;} set{description=value;} }
        public float ForceToApply { get{return forceToApply;} set{forceToApply=value;} }
        public bool FriendlyFire { get{return friendlyFire;} set{friendlyFire=value;} }
        public Vector2 TargetVector { get{return targetVector;} set {targetVector=value;} }
        public AttackType Type { get{return type;} set{type=value;} }
    }
}