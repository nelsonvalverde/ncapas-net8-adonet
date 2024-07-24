using WebApi.Entities.UserRole.Dtos;

namespace WebApi.Data.FirstContext.Repositories.Impl.UserRoleRepository;

public static class UserRoleMapper
{
    public static UserRoleDto ToUserRoleDto(SqlDataReader dataReader)
    {
        return new(
            UserId: ReaderConvert.ToString(dataReader, "USER_ROLE_USER_ID"),
            RoleId: ReaderConvert.ToString(dataReader, "USER_ROLE_ROLE_ID"),
            Created: ReaderConvert.ToDateTime(dataReader, "USER_ROLE_CREATED"),
            CreatedBy: ReaderConvert.ToString(dataReader, "USER_ROLE_CREATED_BY"),
            LastModified: ReaderConvert.ToDateTime(dataReader, "USER_ROLE_LAST_MODIFIED"),
            LastModifiedBy: ReaderConvert.ToString(dataReader, "USER_ROLE_LAST_MODIFIED_BY")
        );
    }
}