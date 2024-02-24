using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data;

public interface IDbContext: IDisposable
{
    DbContext instance { get;}
}