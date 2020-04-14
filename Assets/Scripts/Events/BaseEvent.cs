using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScrollShooter.Events
{
    public class BaseEvent : MonoBehaviour
    {
        private readonly List<Action<Actor>> _callbacks = new List<Action<Actor>>();

        public void Subscribe(Action<Actor> callback)
        {
            _callbacks.Add(callback);
        }

        public void Publish(Actor unit)
        {
            foreach (var callback in _callbacks)
                callback(unit);
        }
    }
}