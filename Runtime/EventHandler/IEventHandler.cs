
namespace ringo.EventSystem
{
    public interface IEventHandler
    {
        public void Handle(IEvent @event);
    }
}