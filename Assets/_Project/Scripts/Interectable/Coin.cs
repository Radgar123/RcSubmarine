using ManagersAndControllers;
using ManagersAndControllers.Audio;

namespace Interectable
{
    public class Coin : Interectable
    {
        public override void Interact()
        {
            //EventManager.instance.WinGame();
            GameManager.instance.winPosition = true;
            //gameObject.SetActive(false);
            AudioManager.instance.PlaySfxAudio(1);
        }
    }
}