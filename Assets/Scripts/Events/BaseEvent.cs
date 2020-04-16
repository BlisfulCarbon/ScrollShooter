using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScrollShooter.Events
{
    public class BaseEvent 
    {
        private readonly List<Action> _callbacks = new List<Action>();

        public void Subscribe(Action callback)
        {
            _callbacks.Add(callback);
        }

        public void Publish()
        {
            foreach (var callback in _callbacks)
                callback();
        }
    }
}