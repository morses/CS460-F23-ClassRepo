using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Simple.Data;
using Simple.DAL.Abstract;
using Simple.Models;
using System.Diagnostics;

// Put this in folder DAL/Concrete
namespace Simple.DAL.Concrete;

public class UserLogRepository : Repository<UserLog>, IUserLogRepository
{ 
    // These can stay using a SimpleDbContext, but we'll actually be providing a UserLogsDbContext, which is a subclass of SimpleDbContext
    public UserLogRepository(SimpleDbContext ctx) : base(ctx)
    {

    }

    public List<UserLog> MostRecentVisit(string aspNetUserId, int count)
    {
        var lastVisits = GetAll(ul => ul.AspnetIdentityId == aspNetUserId)
                            .OrderByDescending(ul => ul.TimeStamp)
                            .Take(count);
        Debug.WriteLine(lastVisits.ToQueryString());
                            
        return lastVisits.ToList();
    }

}