using UnityEngine;
using UnityEngine.Events;

namespace ManagersAndControllers
{
    public class EventManager : Singleton<EventManager>
    {
        #region Events
        
        [HideInInspector] public UnityEvent _startGame;
        

        #endregion

        #region Invokes

        [HideInInspector] public void StartGame(){_startGame.Invoke();}

        #endregion
    }
}