using ScrollShooter.Interfaces;
using UnityEngine;

namespace ScrollShooter.Components
{
    public abstract class BaseComponent : MonoBehaviour, IInteractiveGameObject
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
}
