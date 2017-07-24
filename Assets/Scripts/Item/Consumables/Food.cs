using Assets.Scripts;

/// <summary>
///     A food consumable that applies some manner of health to a player
/// </summary>
public class Food : Consumable
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    public Food()
    {
        Multiplier = 1;
        HealthMod = 5;
    }

    /// <summary>
    ///     The health modifier
    /// </summary>
    public int HealthMod { get; set; }

    /// <summary>
    ///     The health multiplier
    /// </summary>
    public int Multiplier { get; set; }

    /// <summary>
    /// Increases the player's health by HealthMod * Multiplier.
    /// Set up this way for ease of generating different "food/fish" consumables that will provide
    /// different amounts of health.
    /// </summary>
    public override void Consume()
    {
        GameManager.Instance.PlayerHealth += HealthMod * Multiplier;
    }
}