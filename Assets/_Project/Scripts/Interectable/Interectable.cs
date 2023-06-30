using Interfaces;
using ManagersAndControllers;
using UnityEngine;

namespace Interectable
{
    public class Interectable : MonoBehaviour, IInterectable, IDestroyable
    { 
        [SerializeField] protected float secondImpact;
        
        public virtual void Interact()
        {
            EventManager.instance.ImpactOnTime(secondImpact);
        }

        public virtual void ChangeSecondImpact(int impact)
        {
            secondImpact = impact;
        }
    }
}