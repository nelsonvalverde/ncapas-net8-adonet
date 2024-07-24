/*
    Responsable : Nelson Valverde La Torre
    Date        : 08/06/2024
    Description : Create user
*/
CREATE PROCEDURE [dbo].[PROJ_CREATE_USER_SP]
    @ID                 VARCHAR(254),
    @NAME               VARCHAR(70),
    @LAST_NAME          VARCHAR(90),
    @PHONE_NUMBER		VARCHAR(32),
    @EMAIL      		VARCHAR(32),
	@PASSWORD_HASH		VARCHAR(254),
    @EMAIL_CONFIRMED    BIT,
    @BIRTHDAY           DATE,
    @STATUS_ID          TINYINT,
    @CREATED            DATETIME,
    @CREATED_BY         VARCHAR(60),
    @LAST_MODIFIED      DATETIME,
    @LAST_MODIFIED_BY   VARCHAR(60) 

    AS
    SET NOCOUNT ON;

    INSERT INTO [dbo].[User](
        [Id],
        [Name],
        [LastName],
        [PhoneNumber],
        [Email],
        [PasswordHash],
        [EmailConfirmed],
        [Birthday],
        [StatusId],
        [Created],
        [CreatedBy],
        [LastModified],
        [LastModifiedBy]
    ) 
    VALUES(
        @ID,
        @NAME,
        @LAST_NAME,
        @PHONE_NUMBER,
        @EMAIL,
		@PASSWORD_HASH,
        @EMAIL_CONFIRMED,
        @BIRTHDAY,
        @STATUS_ID,
        @CREATED,
        @CREATED_BY,
        @LAST_MODIFIED,
        @LAST_MODIFIED_BY
    )
GO