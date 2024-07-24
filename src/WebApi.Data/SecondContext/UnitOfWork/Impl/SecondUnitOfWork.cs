using WebApi.Data.SecondContext.DbContext;
using WebApi.Data.SecondContext.Repositories;

namespace WebApi.Data.SecondContext.UnitOfWork.Impl;

public sealed class SecondUnitOfWork(
    ISecondDbContext dbContext,
    IEntityRepository entityRepository) : ISecondUnitOfWork
{
    private readonly ISecondDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    private readonly IEntityRepository _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));

    public IEntityRepository EntityRepository => _entityRepository;

    #region Methods


    #endregion Methods
}