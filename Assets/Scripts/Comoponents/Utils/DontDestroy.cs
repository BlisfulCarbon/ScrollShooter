using UnityEngine;

namespace ScrollShooter.Components
{
    public class DontDestroy : MonoBehaviour
    {
        private static bool _isApplicationQuitting;
        public static DontDestroy _instance;


        private void Awake()
        {
            if (_instance == null)
            {
                Debug.Log("Find singleton " + typeof(DontDestroy));
                _instance = FindObjectOfType<DontDestroy>();
            }
            if (_instance == null)
            {
                Debug.Log("Create singleton " + typeof(DontDestroy));
                var singleton = new GameObject("[Singleton] " + typeof(DontDestroy));
                _instance = singleton.AddComponent<DontDestroy>();
            }

            DontDestroyOnLoad(_instance.gameObject);
        }

        public virtual void OnDestroy()
        {
            _isApplicationQuitting = true;
        }
    }
}