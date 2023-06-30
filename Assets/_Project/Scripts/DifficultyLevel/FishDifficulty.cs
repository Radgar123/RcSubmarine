using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Radgar.Difficulty
{
    [CreateAssetMenu(fileName = "FishDifficulty",menuName = "RadgarUtility/Difficulty/FishDifficulty")]
    public class FishDifficulty : ScriptableObject
    {
        public float swimSpeed = 2f;
        public float changeDirectionInterval = 3f;
        public float separationDistance = 1f;
        public float separationForce = 1f;
    }
}


