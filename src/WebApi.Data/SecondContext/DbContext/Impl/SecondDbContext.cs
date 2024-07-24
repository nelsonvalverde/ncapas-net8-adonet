using Microsoft.Extensions.Configuration;
using WebApi.Data.Factory.DbFactory.Impl;

namespace WebApi.Data.SecondContext.DbContext.Impl;

public class SecondDbContext : DbFactory, ISecondDbContext
{
    public SecondDbContext(IConfiguration configuration) : base(configuration.GetConnectionString("AnotherConnection") ?? string.Empty)
    {
    }

    public SecondDbContext(string connectionString) : base(connectionString)
    {
    }
}