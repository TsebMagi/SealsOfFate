﻿namespace Assets.Scripts.Entity {
    /// <summary>
    /// A tag describing defense
    /// </summary>
    public abstract class DefenseTag {
        /// <summary>
        /// Applies the tag to the CombatData
        /// </summary>
        /// <param name="attack">An attack to modify</param>
        public abstract void Apply(ref CombatData attack);
    }

    /// <summary>
    /// A sample implementation of an invicibility tag
    /// </summary>
    internal class Invincible : DefenseTag {
        /// <summary>
        /// Applies the tag to the attack
        /// </summary>
        /// <param name="attack">The attack to be negated by invicibility</param>
        public override void Apply(ref CombatData attack) {
            attack.AttackInfo.Damage = 0;
        }
    }
}