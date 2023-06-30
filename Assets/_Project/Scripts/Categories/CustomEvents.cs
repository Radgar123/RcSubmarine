using Radgar.Difficulty;
using UnityEngine.Events;

namespace Categories
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float>
    {
        
    }

    [System.Serializable]
    public class DifficultyEvent : UnityEvent<Difficulty>
    {
        
    }
}