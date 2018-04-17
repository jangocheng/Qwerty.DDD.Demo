using System;
using Framework.Domain.Core;
using Framework.Infrastructure.Interfaces.Core.Event;

namespace Qwerty.DDD.Domain.Events
{
    public class UserIdentity:IAggregateRoot,IEvent
    {
        public long UserId { get; set; }
        public long RealName { get; set; }
        public long IdentityNo { get; set; }
    }
}
