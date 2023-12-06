using UnityEngine;

namespace Thayane.Core.Utils
{
    public class PauseGame : Singletons.Singleton<PauseGame>
    {
        private void Start()
        {
            Pause(false);
        }

        public void Pause(bool pause)
        {
            Time.timeScale = pause ? 0f : 1f;
        }
    }
}
