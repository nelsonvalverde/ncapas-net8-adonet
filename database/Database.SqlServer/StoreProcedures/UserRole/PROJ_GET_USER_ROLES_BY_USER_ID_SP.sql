/*
    Responsable : Nelson Valverde La Torre
    Date        : 13/06/2024
    Description : Get roles by user
*/
CREATE PROCEDURE [dbo].[PROJ_GET_USER_ROLES_BY_USER_ID_SP]
    @USER_ID VARCHAR(254)
    AS
    SET NOCOUNT ON;

    SELECT  
            [UserId]            AS  USER_ROLE_USER_ID,
            [RoleId]            AS  USER_ROLE_ROLE_ID,
            [Created]           AS  USER_ROLE_CREATED,
            [CreatedBy]         AS  USER_ROLE_CREATED_BY,
            [LastModified]      AS  USER_ROLE_LAST_MODIFIED,
            [LastModifiedBy]    AS  USER_ROLE_LAST_MODIFIED_BY
    FROM    [dbo].[UserRole] (NOLOCK)
    WHERE   UserId = @USER_ID
GO