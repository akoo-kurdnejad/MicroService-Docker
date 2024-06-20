namespace EventBus.Messages.Events.Base
{
    public class BaseEvent
    {
        public BaseEvent()
        {
            this.EventId = Guid.NewGuid();   
            this.CreateDate = DateTime.UtcNow;
        }

        public BaseEvent(Guid eventId, DateTime createDate)
        {
            EventId = eventId;
            CreateDate = createDate;
        }

        public Guid EventId { get; private set; }
        public DateTime CreateDate { get; private set; }
    }
}
