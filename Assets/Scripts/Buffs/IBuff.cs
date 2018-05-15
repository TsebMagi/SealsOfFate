using UnityEngine;
using Entity;
using System.Collections;

namespace Buff{
public interface IBuff{
    void Apply(EntityBehaviour applyTo);
    IEnumerator Process();
    void Remove();
}
}