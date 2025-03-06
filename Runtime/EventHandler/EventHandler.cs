namespace ringo.EventSystem
{
    public abstract class EventHandler<T> : IEventHandler where T : IEvent
    {
        public EventHandler()
        {
            EventBus.Subscribe<T>(this);
        }

        public abstract void Handle(IEvent @event);
    }
}