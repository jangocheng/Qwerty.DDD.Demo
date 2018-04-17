using Framework.Infrastructure.Interfaces.Core;
using Framework.Infrastructure.Interfaces.Core.Event;
using Framework.Infrastructure.Ioc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Qwerty.DDD.Domain.Events;
using System.Threading.Tasks;

namespace Qwerty.DDD.Domain.EventHandlers
{
    public class UserEventHanler:IEventHandler<UserIdentity>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly bool _isCommit;
        public UserEventHanler(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext is null)
            {
                _unitOfWork = ServiceLocator.Instance.GetService<IUnitOfWork>();
                _isCommit = true;
            }
            else
            {
                _unitOfWork = httpContextAccessor.HttpContext.RequestServices.GetService<IUnitOfWork>();
                _isCommit = false;
            }
        }

        public async Task Handle(UserIdentity @event)
        {
            await _unitOfWork.RegisterNew(@event);
            if (_isCommit) await _unitOfWork.CommitAsync();
        }
    }
}
