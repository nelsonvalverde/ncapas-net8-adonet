/*
    Responsable : Nelson Valverde La Torre
    Date        : 13/06/2024
    Description : Assign Role to User
*/
CREATE PROCEDURE [dbo].[PROJ_ASSIGN_ROLE_TO_USER_SP]
    @USER_ID                VARCHAR(254),
    @ROLE_ID                VARCHAR(254),
    @CREATED                DATETIME,
    @CREATED_BY             VARCHAR(60),
    @LAST_MODIFIED          DATETIME,
    @LAST_MODIFIED_BY       VARCHAR(60) 

    AS
    SET NOCOUNT ON;

    INSERT INTO [dbo].[UserRole](
        [UserId],
        [RoleId],
        [Created],
        [CreatedBy],
        [LastModified],
        [LastModifiedBy]
    ) 
    VALUES(
        @USER_ID,
        @ROLE_ID,
        @CREATED,
        @CREATED_BY,
        @LAST_MODIFIED,
        @LAST_MODIFIED_BY
    )
GO