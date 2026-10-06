namespace AuditApp.Log.Service.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAuditInfoAsync(string action, string entityName, string entityId, string userId, string details);

        Task<IEnumerable<string>> GetLogsAsync(string entityName, string entityId);

        Task<string> GetLogDetailsAsync(string logId);

    }
}
