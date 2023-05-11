﻿using Neqatcom.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.Service
{
    public interface INotificationsService
    {
        Notification GetNotificationById(int id);
        void CreateNewNotification(Notification notification);
    }
}