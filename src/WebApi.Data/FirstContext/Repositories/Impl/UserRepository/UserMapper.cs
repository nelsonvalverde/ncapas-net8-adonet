using WebApi.Entities.User.Dtos;
using WebApi.Entities.User.Enums;

namespace WebApi.Data.FirstContext.Repositories.Impl.UserRepository;

public static class UserMapper
{
    public static UserDto ToUserDto(SqlDataReader dataReader)
    {
        return new(
            Id: ReaderConvert.ToString(dataReader, "USER_ID"),
            Name: ReaderConvert.ToString(dataReader, "USER_NAME"),
            LastName: ReaderConvert.ToString(dataReader, "USER_LAST_NAME"),
            FullName: ReaderConvert.ToString(dataReader, "USER_FULL_NAME"),
            Birthday: ReaderConvert.ToDateOnly(dataReader, "USER_BIRTHDAY"),
            Email: ReaderConvert.ToString(dataReader, "USER_EMAIL"),
            PasswordHash: ReaderConvert.ToStringNull(dataReader, "USER_PASSWORD_HASH"),
            PhoneNumber: ReaderConvert.ToString(dataReader, "USER_PHONE_NUMBER"),
            EmailConfirmed: ReaderConvert.ToBool(dataReader, "USER_EMAIL_CONFIRMED"),
            StatusId: (UserStatus)ReaderConvert.ToInt32(dataReader, "USER_STATUS_ID"),
            Created: ReaderConvert.ToDateTime(dataReader, "USER_CREATED"),
            CreatedBy: ReaderConvert.ToString(dataReader, "USER_CREATED_BY"),
            LastModified: ReaderConvert.ToDateTime(dataReader, "USER_LAST_MODIFIED"),
            LastModifiedBy: ReaderConvert.ToString(dataReader, "USER_LAST_MODIFIED_BY")
        );
    }
}