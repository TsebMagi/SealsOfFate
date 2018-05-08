using System;
using UnityEngine;

namespace Combat {
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
        /// <param name="damage">The amount of pain to inflict</param>
        /// <param name="damageType">The manner in which it is inflicted</param>
        /// <param name="forceToApply">The amount of force this attack inflicts</param>
        /// <param name="description">A human readable description (such as "laserjet printer")</param>
        public AttackStats(int damage, DamageType[] damageType, float forceToApply ,string description) {
            Damage = damage;
            DamageType = damageType;
            Description = description;
            ForceToApply = forceToApply;
        }

        public virtual void Update(){}
        public virtual void SpecialEffect(){return;}
        /// <summary>
        ///     The damage done by this Attack
        /// </summary>
        [SerializeField]
        private int damage;
        /// <summary>
        ///     The types of damage done by this Attack
        /// </summary>
        [SerializeField]
        private DamageType[] damageType;
        /// <summary>
        ///     A description of the Attack (e.g. sword, tentacle, burning fart)
        /// </summary>
        [SerializeField]
        private string description;
        /// <summary>
        ///     The amount of force this attack applies
        /// </summary>
        [SerializeField]
        private float forceToApply;
        /// <summary>
        ///     Does the Attack cause friendly fire?
        /// </summary>
        [SerializeField]
        private bool friendlyFire;
        /// <summary>
        ///     Vector to move toward for Ranged Attacks and Vector to calculate from for Melee Attacks
        /// </summary>
        private Vector2 targetVector;

        public string Description { get; set; }
        public float ForceToApply { get; set; }
        public bool FriendlyFire { get; set; }
        public DamageType[] DamageType { get; set; }
        public int Damage { get; set; }
        public Vector2 TargetVector { get; set; }
    }
}