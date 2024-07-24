using WebApi.Shared.Services.PasswordHashService;

namespace Test.WebApi.Shared;

public class PassWordHashTest()
{
    private readonly IPasswordHashService _passwordHashService = new PasswordHashService();

    [Fact]
    public void HashPassword_Should_Return_HashedPassword()
    {
        //Arrange
        var passowrd = "@Password123.";

        //Act
        var hashedPassword = _passwordHashService.HashPassword(passowrd);

        //Assert
        Assert.NotNull(hashedPassword);
        Assert.NotEqual(passowrd, hashedPassword);

    }

    [Fact]
    public void VerifyPassword_Should_Return_True_For_CorrectPassword()
    {
        //Arrange
        var passowrd = "@Password123.";
        var hashedPassword = _passwordHashService.HashPassword(passowrd);

        //Act
        var result = _passwordHashService.VerifyPassword(passowrd, hashedPassword);

        //Assert
        Assert.True(result);

    }
    [Fact]
    public void VerifyPassword_Should_Return_False_For_IncorrectPassword()
    {
        // Arrange
        var password = "@Password123.";
        var hashedPassword = _passwordHashService.HashPassword(password);
        var incorrectPassword = "WrongPassword";

        // Act
        var result = _passwordHashService.VerifyPassword(incorrectPassword, hashedPassword);

        // Assert
        Assert.False(result);
    }
}