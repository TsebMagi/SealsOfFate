using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Consumable {

    public int Modifier;
    public int HealthMod;

    public Fish()
    {
        Modifier = 1;
        HealthMod = 5;
    }

    public override void Consume()
    {
        //Increases the player's health by 5 * the set modifier for the fish in the unity engine.
        //Set up this way for ease of generating different "food/fish" consumables that will provide
        //different amounts of health.
        GameManager.instance.playerHealth += HealthMod * Modifier;
    }

}
