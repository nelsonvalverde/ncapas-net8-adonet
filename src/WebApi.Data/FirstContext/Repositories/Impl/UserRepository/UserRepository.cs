using WebApi.Data.Factory.DbFactory.Impl;
using WebApi.Data.FirstContext.DbContext;
using WebApi.Entities.Base;
using WebApi.Entities.User.Dtos;
using WebApi.Shared.Services.DateTimeService;
using WebApi.Shared.Services.UserService;

namespace WebApi.Data.FirstContext.Repositories.Impl.UserRepository;

public sealed class UserRepository(
    IFirstDbContext dbContext,
    IDateTimeService dateTimeService,
    IUserService userService) : IUserRepository
{
    private readonly IFirstDbContext _dbContext = dbContext;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IUserService _userService = userService;

    public async Task CreateAsync(CreateUserDto user, CancellationToken cancellationToken = default)
    {
        var parameters = new SqlParameter[]
        {
            new("@ID", user.Id),
            new("@NAME", user.Name),
            new("@LAST_NAME", user.LastName),
            new("@PHONE_NUMBER", user.PhoneNumber),
            new("@EMAIL", user.Email),
            new("@PASSWORD_HASH", user.PasswordHash),
            new("@BIRTHDAY", user.Birthday),
            new("@EMAIL_CONFIRMED", user.EmailConfirmed),
            new("@STATUS_ID", user.StatusId),
            new("@CREATED", _dateTimeService.GetDateTimeUtc),
            new("@CREATED_BY", _userService.UserId),
            new("@LAST_MODIFIED_BY", _userService.UserId),
            new("@LAST_MODIFIED", _dateTimeService.GetDateTimeUtc),
        };

        await _dbContext.ExecuteNonQueryAsync(DbSchema.Schema.dbo, "PROJ_CREATE_USER_SP", parameters, cancellationToken);
    }

    public async Task UpdateUserStatusAsync(UpdateUserStatusDto user, CancellationToken cancellationToken = default)
    {
        var parameters = new SqlParameter[]
        {
            new("@ID", user.Id),
            new("@STATUS_ID", user.StatusId),
            new("@LAST_MODIFIED_BY", _userService.UserId),
            new("@LAST_MODIFIED", _dateTimeService.GetDateTimeUtc)
        };

        await _dbContext.ExecuteNonQueryAsync(DbSchema.Schema.dbo, "PROJ_UPDATE_USER_STATUS_SP", parameters, cancellationToken);
    }

    public async Task<DataList<UserDto>> FilterAsync(string? filterName = null, CancellationToken cancellationToken = default)
    {
        var list = new List<UserDto>();
        var parameters = new SqlParameter[]
        {
            new("@FILTER", filterName),
        };

        await _dbContext.DataReaderAsync(
           schema: DbSchema.Schema.dbo,
           storedProcedure: "PROJ_FILTER_USER_SP",
           readerAction: (reader) =>
           {
               list.Add(UserMapper.ToUserDto(reader));
           },
           parameters: parameters,
           cancellationToken: cancellationToken
        );

        return new DataList<UserDto>
        {
            List = list,
            TotalRecord = list.Count
        };
    }

    public async Task<UserDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        UserDto? user = null;
        var parameters = new SqlParameter[]
        {
            new("@ID", id)
        };

        await _dbContext.DataReaderAsync(
           schema: DbSchema.Schema.dbo,
           storedProcedure: "PROJ_GET_USER_BY_ID_SP",
           readerAction: (reader) =>
           {
               user = UserMapper.ToUserDto(reader);
           },
           parameters: parameters,
           cancellationToken: cancellationToken
        );

        return user;
    }

    public async Task<UserDto?> AuthUserAsync(string email, CancellationToken cancellationToken = default)
    {
        UserDto? user = null;
        var parameters = new SqlParameter[]
        {
            new("@EMAIL", email)
        };

        await _dbContext.DataReaderAsync(
           schema: DbSchema.Schema.dbo,
           storedProcedure: "PROJ_AUTH_USER_SP",
           readerAction: (reader) =>
           {
               user = UserMapper.ToUserDto(reader);
           },
           parameters: parameters,
           cancellationToken: cancellationToken
        );

        return user;
    }

    public async Task<DataPage<UserDto>> GetPageAsync(string? filterName = null, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var list = new List<UserDto>();

        var parameterOuput = new SqlParameter("@TOTAL_RECORD", SqlDbType.Int) { Direction = ParameterDirection.Output };

        var parameters = new SqlParameter[]
        {
            new("@FILTER", filterName),
            new("@PAGE_NUMBER", pageNumber),
            new("@PAGE_SIZE", pageSize),
            parameterOuput
        };

        await _dbContext.DataReaderAsync(
           schema: DbSchema.Schema.dbo,
           storedProcedure: "PROJ_PAGE_USER_SP",
           readerAction: (reader) =>
           {
               list.Add(UserMapper.ToUserDto(reader));
           },
           parameters: parameters,
           cancellationToken: cancellationToken
        );

        var result = new DataPage<UserDto>()
        {
            List = list,
            TotalRecord = Convert.ToInt32(parameterOuput.Value),
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        return result;
    }

    public async Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken = default)
    {
        var parameters = new SqlParameter[]
        {
            new("@ID", user.Id),
            new("@NAME", user.Name),
            new("@LAST_NAME", user.LastName),
            new("@BIRTHDAY", user.Birthday),
            new("@LAST_MODIFIED_BY", _userService.UserId),
            new("@LAST_MODIFIED", _dateTimeService.GetDateTimeUtc),
        };

        await _dbContext.ExecuteNonQueryAsync(DbSchema.Schema.dbo, "PROJ_UPDATE_USER_SP", parameters, cancellationToken);
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        UserDto? user = null;
        var parameters = new SqlParameter[]
        {
            new("@EMAIL", email)
        };

        await _dbContext.DataReaderAsync(
           schema: DbSchema.Schema.dbo,
           storedProcedure: "PROJ_GET_USER_BY_EMAIL_SP",
           readerAction: (reader) =>
           {
               user = UserMapper.ToUserDto(reader);
           },
           parameters: parameters,
           cancellationToken: cancellationToken
        );

        return user;
    }
}