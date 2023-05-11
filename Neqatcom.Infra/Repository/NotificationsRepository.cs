using Dapper;
using Microsoft.EntityFrameworkCore;
using Neqatcom.Core.Common;
using Neqatcom.Core.Data;
using Neqatcom.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Neqatcom.Infra.Repository
{
    public class NotificationsRepository:INotificationsRepository
    {
        private readonly IDbContext dbContext;
        public NotificationsRepository(IDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public void CreateNewNotification(Notification notification)
        {
            var p = new DynamicParameters();
            p.Add("Message", notification.Notificationsmessage, DbType.String, direction: ParameterDirection.Input);
            p.Add("useridd", notification.Userid, DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("GP_Notifications_PACKAGE.CreateNotifications", p, commandType: CommandType.StoredProcedure);
        }

        public List< Notification> GetNotificationById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id_", id, DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Notification> notifications = dbContext.Connection.Query<Notification>("GP_Notifications_PACKAGE.GetNotificationsById", p, commandType: CommandType.StoredProcedure);
            return notifications.ToList();
        }
    }
}
