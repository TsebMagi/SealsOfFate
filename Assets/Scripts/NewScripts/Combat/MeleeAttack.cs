using UnityEngine;
using System;

namespace Combat{
    public class MeleeAttack : AttackStats {
        MeleeAttack(int damage, DamageType[] damageTypes, float forceToApply, string description):base(damage,damageTypes,forceToApply,description){

        }
    }
}