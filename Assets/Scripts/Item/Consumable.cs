using UnityEngine;
using System.Collections;
using Buff;
//TODO: examine and implement entire Consumable Hierarchy
/// <summary>
/// Consumable object - does something to the critter picking it up
/// </summary>
public abstract class Consumable : MonoBehaviour, IBuff, IInteractable
{
    //    public int HealthMod;
    //   public int ManaMod;

    /// <summary>
    /// Implementation of the IInteractable interface
    /// </summary>
    /// <remarks>Calls Consumable.Consume()
    /// </remarks>
    public virtual void Interact()
    {
        Consume();
    }
    /// <summary>
    /// Consumes the object
    /// </summary>
    public virtual void Consume()
    {
        // GameManager.instance.playerHealth += HealthMod;
        //     GameManager.instance.playerMana += ManaMod;
        // TODO Add a death animation
        this.gameObject.SetActive(false);
        Debug.Log("The Seal has consumed an item!");
        Destroy(gameObject);
    }
    public virtual void Apply(Entity.EntityBehaviour applyTo){

    }
    public virtual IEnumerator Process(){
        return null;
    }
    public virtual void Remove(){

    }


}