using System;
using System.Collections.Generic;

namespace ringo.EventSystem
{
    public static class EventBus
    {
        // TODO: Make sure this resets on domain reload
        private static Dictionary<Type, List<EventHandler<IEvent>>> _handlers = new();
        
        public static void Subscribe<T>(EventHandler<IEvent> handler) where T : IEvent
        {
            _handlers.Add(typeof(T), new List<EventHandler<IEvent>>());
        }
        
        public static void Unsubscribe<T>(T @event, EventHandler<IEvent> handler) where T : IEvent
        {
            _handlers[@event.GetType()].Remove(handler);
        }
        
        public static void Publish<T>(T @event) where T : IEvent
        {
            var handlers = _handlers[@event.GetType()];

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}