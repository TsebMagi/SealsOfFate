using System;
using UnityEngine;
//TODO: implement Editor for DefenseStats 
//TODO: design and implement system for modifying defense stats
namespace Combat {
    /// <summary>
    ///     Information about defense
    /// </summary>
    [Serializable]
    public class DefenseStats: ScriptableObject {
        private const int MaxDamageMitigation = 100;
        private byte _damageMitigation;
        private DamageType[] damageTypes;

        /// <summary>
        ///     Creates a new defense information object that describes the type of damage mitigated and what percentage is
        ///     mitigated
        /// </summary>
        /// <param name="damageType">The type of damage being mitigated</param>
        /// <param name="damageMitigation">A value from 0 to 100. Values over 100 are forced to 100.</param>
        public DefenseStats(DamageType[] DamageTypes, byte damageMitigation) {
            damageTypes = DamageTypes;

            DamageMitigation = damageMitigation;
        }

        /// <summary>
        ///     The type of damage mitigated
        /// </summary>
        public DamageType[] DamageTypes { get{return damageTypes;} set{damageTypes=value;} }

        /// <summary>
        ///     The percentage (0 to 100) of damage mitigated
        /// </summary>
        public int DamageMitigation {
            get { return _damageMitigation; }
            private set { _damageMitigation = (byte) (value > MaxDamageMitigation ? MaxDamageMitigation : value); }
        }
    }
}