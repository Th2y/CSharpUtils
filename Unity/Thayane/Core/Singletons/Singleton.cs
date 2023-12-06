using UnityEngine;

namespace Thayane.Core.Singletons
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected bool DontDestroy = false;

        public static T Instance;

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = GetComponent<T>();

                if(DontDestroy) DontDestroyOnLoad(Instance);
            }
            else Destroy(gameObject);
        }
    }
}
