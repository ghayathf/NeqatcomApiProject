using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neqatcom.Core.Data;
using Neqatcom.Core.Service;

namespace Neqatcom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private readonly INotificationsService _notificationsService;
        public NotificationController(INotificationsService notificationsService)
        {

            this._notificationsService = notificationsService;


        }

        [HttpGet]
        public Notification GetNotificationById(int id)
        {
           return _notificationsService.GetNotificationById(id);
        }
        [HttpPost]
       public void CreateNewNotification(Notification notification)
        {
            _notificationsService.CreateNewNotification(notification);
        }
    }
}
