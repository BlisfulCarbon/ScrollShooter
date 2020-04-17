using ScrollShooter.Interfaces;
using UnityEngine;

    public abstract class BaseComponent : MonoBehaviour, InteractiveGameObject
    {
        public void OnEnable()
        {
            this.gameObject.SetActive(true);
        }

        public void OnDisable()
        {
            this.gameObject.SetActive(false);
        }
    }
