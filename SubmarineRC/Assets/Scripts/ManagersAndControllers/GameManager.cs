namespace ManagersAndControllers
{
    public class GameManager : Singleton<GameManager>
    {
        public string playerName;
        public int playerTime;
        public int gameTimeInMinutes;
    }
}