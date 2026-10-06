using AuditApp.DataAccess.DataContext;
using AuditApp.Log.Service.Interfaces;

namespace AuditApp.Log.Service.Implements
{
    public class AuditLogService(EmpAuditPgsqlDbContext dbContext) : IAuditLogService
    {
        public Task<string> GetLogDetailsAsync(string logId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetLogsAsync(string entityName, string entityId)
        {
            throw new NotImplementedException();
        }

        public Task LogAuditInfoAsync(string action, string entityName, string entityId, string userId, string details)
        {
            throw new NotImplementedException();
        }
    }
}
