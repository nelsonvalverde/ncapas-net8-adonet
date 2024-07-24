﻿/*
    Responsable : Nelson Valverde La Torre
    Date        : 08/06/2024
    Description : Get user by id
*/
CREATE PROCEDURE [dbo].[PROJ_GET_USER_BY_ID_SP]
    @ID VARCHAR(254)
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
    FROM    [dbo].[User] (NOLOCK)
    WHERE   Id = @ID
     
GO  