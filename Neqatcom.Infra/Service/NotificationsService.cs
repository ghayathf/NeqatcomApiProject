using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using Neqatcom.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Infra.Service
{
    public class NotificationsService : INotificationsService
    {
        private readonly INotificationsRepository _notificationsRepository;
        public NotificationsService(INotificationsRepository notificationsRepository)
        {
            this._notificationsRepository = notificationsRepository;
        }
        public void CreateNewNotification(Notification notification)
        {
            _notificationsRepository.CreateNewNotification(notification);
        }

        public List< Notification> GetNotificationById(int id)
        {
            return _notificationsRepository.GetNotificationById(id);
        }
    }
}

