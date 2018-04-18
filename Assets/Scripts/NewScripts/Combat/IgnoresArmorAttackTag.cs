using System;
using UnityEngine;
using System.Collections;
using Combat;

[Serializable]
public class IgnoresArmorAttackTag : AttackTag
{
    /// <summary>
    /// Set the defender's armor to 0.
    /// </summary>
    /// <param name="cd">The defender's combat data</param>
    public override void Apply(ref TemporaryCombatData cd)
    {
        cd.Armor = 0;
    }
}
