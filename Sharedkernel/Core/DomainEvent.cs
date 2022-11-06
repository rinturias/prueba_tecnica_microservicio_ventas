using MediatR;

namespace Sharedkernel.Core
{


    public abstract class DomainEvent : INotification
    {
        public DateTime OccuredOn { get; }
        public Guid Id { get; }

        protected DomainEvent(DateTime occuredOn)
        {
            OccuredOn = occuredOn;
            Id = Guid.NewGuid();
        }
    }
}
