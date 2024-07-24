/*
    Responsable : Nelson Valverde La Torre
    Date        : 08/06/2024
    Description : Filter user
*/
CREATE PROCEDURE [dbo].[PROJ_FILTER_USER_SP]
    @FILTER VARCHAR(254) = NULL
    AS
    SET NOCOUNT ON;

    SELECT  
            [Id]                AS  USER_ID,
            [Name]              AS  USER_NAME,
            [LastName]          AS  USER_LAST_NAME,
            [FullName]          AS  USER_FULL_NAME,
            [Email]             AS  USER_EMAIL,
            [PhoneNumber]       AS  USER_PHONE_NUMBER,
            [EmailConfirmed]    AS  USER_EMAIL_CONFIRMED,
            [Birthday]          AS  USER_BIRTHDAY,
            [StatusId]          AS  USER_STATUS_ID,
            [Created]           AS  USER_CREATED,
            [CreatedBy]         AS  USER_CREATED_BY,
            [LastModified]      AS  USER_LAST_MODIFIED,
            [LastModifiedBy]    AS  USER_LAST_MODIFIED_BY
    FROM    [dbo].[User] WITH(NOLOCK, INDEX=IDX_User_FullName)
    WHERE   @FILTER IS NOT NULL OR [FullName] LIKE '%'+@FILTER+'%'
     
GO  