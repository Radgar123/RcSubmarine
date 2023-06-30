using UnityEngine;

namespace Radgar.Difficulty
{
    [CreateAssetMenu(fileName = "LevelDifficulty",menuName = "RadgarUtility/Difficulty/GameLevelDifficulty")]
    public class Difficulty : ScriptableObject
    {
        public int timeGameEnd;
        public int numberOfFish;
        public FishDifficulty fishDifficulty;
    }
}

