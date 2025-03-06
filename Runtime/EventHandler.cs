using System;

namespace ringo.EventSystem
{
    public class EventHandler<T> : IEventHandler where T : IEvent
    {
        Action _callback;

        public EventHandler(Action callback)
        {
            _callback = callback;

            EventBus.Subscribe<T>(this);
        }

        public void Handle(IEvent @event)
        {
            _callback.Invoke();
        }
    }
}