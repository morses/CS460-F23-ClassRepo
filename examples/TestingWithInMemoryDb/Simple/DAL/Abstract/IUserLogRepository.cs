using Simple.Models;

namespace Simple.DAL.Abstract;

public interface IUserLogRepository : IRepository<UserLog>
{
    List<UserLog> MostRecentVisit(string aspNetUserId, int count);
}