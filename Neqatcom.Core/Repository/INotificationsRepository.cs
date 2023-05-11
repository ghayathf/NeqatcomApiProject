using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Repository
{
    public interface INotificationsRepository
    {
        Notification GetNotificationById(int id);
        void CreateNewNotification(Notification notification);
    }
}
