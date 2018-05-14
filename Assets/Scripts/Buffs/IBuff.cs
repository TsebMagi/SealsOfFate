using UnityEngine;
using Entity;
using System.Collections;


public interface IBuff{
    void apply(EntityBehaviour applyTo);
    IEnumerator process();
    void remove(EntityBehaviour removeFrom);
}