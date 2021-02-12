using System;
using MediatR;
using System.Collections.Generic;

namespace Booking.Domain.Seedwork
{
    public abstract class Entity
    {
        int id;
        public virtual int Id
        {
            get => id;
            protected set => id = value;
        }

        public virtual bool IsTransient => Id == default;

        public DateTime CreatedAt { get; set; }

        #region Domain Events

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        #endregion

    }
}
