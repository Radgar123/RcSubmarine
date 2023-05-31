using UnityEngine;

namespace ManagersAndControllers.ObjectPooling
{
    [System.Serializable]
    public struct ObjectToPool
    {
        public GameObject objectToPool;
        public int amount;
    }
}