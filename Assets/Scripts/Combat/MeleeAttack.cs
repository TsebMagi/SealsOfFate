using UnityEngine;
using System;
//TODO: Design and Implement class
namespace Combat{
    public class MeleeAttack : AttackStats {
        MeleeAttack(AttackType Type, int Damage, DamageType[] DamageTypes, float ForceToApply, string Description):base(Type,Damage,DamageTypes,ForceToApply,Description){

        }
    }
}