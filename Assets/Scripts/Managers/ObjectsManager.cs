using System.Linq;
using ScrollShooter.Components;
using ScrollShooter.Events;
using ScrollShooter.Interfaces;
using UnityEngine;

namespace ScrollShooter.Managers
{
    public class ObjectsManager : BaseManager
    {
        private void Awake()
        {
            EventsAggregator.gameOver.Subscribe(StopAllEnemys);
        }

        private void StopAllEnemys()
        {
            foreach (var enemy in FindObjectsOfType<MonoBehaviour>().OfType<IActor>())
            {
                enemy.OnDisable();
            }
        }
    }
}