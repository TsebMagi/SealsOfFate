using Assets.Scripts;
using Combat;
using UnityEngine;
/// <summary>
///     A food consumable that applies some manner of health to a player
/// </summary>
public class Food : Consumable {
    /// <summary>Default constructor </summary>
    public Food() {
    }
    public Food(ushort healthMod, ushort multiplier){
        this.healthMod = healthMod;
        this.multiplier = multiplier;
    }

    /// <summary>The health modifier </summary>
    public ushort HealthMod { get{return healthMod;} set{healthMod=value;} }

    /// <summary>The health multiplier </summary>
    public ushort Multiplier { get{return multiplier;} set{multiplier=value;} }

    /// <summary>
    ///     Increases the player's health by HealthMod * Multiplier.
    ///     Set up this way for ease of generating different "food/fish" consumables that will provide
    ///     different amounts of health.
    /// </summary>
    public override void Consume() {
        base.Consume();
    }

    [SerializeField]
    private ushort healthMod;
    [SerializeField]
    private ushort multiplier;
}