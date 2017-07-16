using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Consumable {

    public int Modifier;
    public int HealthMod;

    public Fish()
    {
        Modifier = 1;
        HealthMod = 20;
    }

    public override void Consume()
    {
        GameManager.instance.playerHealth += HealthMod;
    }

}
