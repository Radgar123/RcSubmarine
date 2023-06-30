using Categories;
using Radgar.Singleton;
using UnityEngine;
using UnityEngine.Events;

namespace ManagersAndControllers
{
    public class EventManager : Singleton<EventManager>
    {
        #region Events
        
        [HideInInspector] public UnityEvent _startGame;
        [HideInInspector] public UnityEvent _endGame;
        [HideInInspector] public UnityEvent _winGame;
        [HideInInspector] public FloatEvent _impactOnTime;

        #endregion

        #region Invokes

        public void StartGame(){_startGame.Invoke();}
        public void EndGame(){_endGame.Invoke();}
        public void WinGame(){_winGame.Invoke();}
        public void ImpactOnTime(float time){_impactOnTime.Invoke(time);}
        #endregion
    }
}