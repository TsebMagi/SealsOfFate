using UnityEngine;
using System.Collections;

namespace Buff{
    public interface IBuffable{
        void AddBuff(IBuff toAdd);

        void RemoveBuff(IBuff toRemove);
    }
}