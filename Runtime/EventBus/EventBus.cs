using System;
using System.Collections.Generic;
using UnityEngine;

namespace ringo.EventSystem
{
    public static class EventBus
    {
        // TODO: Make sure this resets on domain reload
        private static Dictionary<Type, List<IEventHandler>> _handlers = new();
        
        public static void Subscribe<T>(IEventHandler handler) where T : IEvent
        {
            if (handler == null)
            {
                Debug.LogWarning("[EventBus] Subscribed to null subscriber");
                return;
            }
            
            if (_handlers.ContainsKey(typeof(T)))
            {
                _handlers[typeof(T)].Add(handler);
                return;
            }

            var newHandlerList = new List<IEventHandler> { handler };
            _handlers.Add(typeof(T), newHandlerList);
        }
        
        public static void Unsubscribe<T>(T @event, EventHandler<IEvent> handler) where T : IEvent
        {
            _handlers[@event.GetType()].Remove(handler);
        }
        
        public static void Publish<T>(T @event) where T : IEvent
        {
            if (!_handlers.ContainsKey(@event.GetType()))
                return;
            
            var handlers = _handlers[@event.GetType()];

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}