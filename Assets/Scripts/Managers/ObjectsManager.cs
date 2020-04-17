using System.Linq;
using ScrollShooter.Interfaces;
using UnityEngine;

namespace ScrollShooter.Managers
{
    public class ObjectsManager : BaseManager
    {
        private void Awake()
        {
            EventsManager.gameOver.Subscribe(StopAllEnemys);
        }

        private void StopAllEnemys()
        {
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>().OfType<InteractiveGameObject>())
            {
                enemy.OnDisable();
            }
        }
    }
}