using UnityEngine;

namespace ScrollShooter.Managers
{
    public abstract class BaseManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static bool isApplicationQuitting;
        private static T _instance;
        private static readonly object _lock = new object();

        private static T Instance
        {
            get
            {
                Debug.Log("Get instance manager " + typeof(T));
                if (isApplicationQuitting)
                    return null;

                lock (_lock)
                {
                    if (_instance == null) _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        Debug.Log("Create singleton " + typeof(T));
                        var singleton = new GameObject("[Singleton] " + typeof(T));
                        _instance = singleton.AddComponent<T>();
                    }

                    DontDestroyOnLoad(_instance.gameObject);
                    return _instance;
                }
            }
        }
        
        public virtual void OnDestroy()
        {
            isApplicationQuitting = true;
        }
    }
}