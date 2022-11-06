using MediatR;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Sales.Domain.Interfaces;
using System.Sales.Infrastructure.EF.Context;
using System.Text;
using System.Threading.Tasks;

namespace System.Sales.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(WriteDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task Commit()
        {
            //Publicar eventos de dominio
            var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToArray();

            foreach (var @event in domainEvents)
            {
                await _mediator.Publish(@event);
            }

            await _context.SaveChangesAsync();

            foreach (var @event in domainEvents)
            {
                Type type = typeof(ConfirmedDomainEvent<>)
                    .MakeGenericType(@event.GetType());

                var confirmedEvent = (INotification)Activator
                    .CreateInstance(type, @event);


                await _mediator.Publish(confirmedEvent);
            }
        }
    }
}