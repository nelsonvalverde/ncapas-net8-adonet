/*
    Responsable : Nelson Valverde La Torre
    Date        : 08/06/2024
    Description : User pages
*/
CREATE PROCEDURE [dbo].[PROJ_PAGE_USER_SP]
    @FILTER         VARCHAR(254) = NULL,
    @PAGE_NUMBER    INT,
    @PAGE_SIZE      INT,
    @TOTAL_RECORD   INT OUTPUT
    AS
    SET NOCOUNT ON;
    
    CREATE TABLE #TempUser (
        [Id]                VARCHAR(254),
        [Name]              VARCHAR(60),
        [LastName]          VARCHAR(90),
        [FullName]          VARCHAR(150),
        [PhoneNumber]       VARCHAR(32),
        [Email]             VARCHAR(120),
	    [PasswordHash]	    VARCHAR(254),
        [Birthday]          DATE,
        [EmailConfirmed]    BIT,
        [StatusId]          TINYINT,
        [CreatedBy]         VARCHAR(60),
        [Created]           DATETIME,
        [LastModifiedBy]    VARCHAR(60),
        [LastModified]      DATETIME
    )

    INSERT INTO #TempUser
            (
                [Id],
                [Name],
                [LastName],
                [FullName],
                [Email],
                [PhoneNumber],
                [EmailConfirmed],
                [Birthday],
                [StatusId],
                [Created],
                [CreatedBy],
                [LastModified],
                [LastModifiedBy]
            )
    SELECT      [Id],
                [Name],
                [LastName],
                [FullName],
                [Email],
                [PhoneNumber],
                [EmailConfirmed],
                [Birthday],
                [StatusId],
                [Created],
                [CreatedBy],
                [LastModified],
                [LastModifiedBy]
    FROM        [dbo].[User] WITH(NOLOCK, INDEX=IDX_User_FullName)
    WHERE       @FILTER IS NULL OR [FullName] LIKE '%'+@FILTER+'%'

    SET @TOTAL_RECORD = (SELECT COUNT(1) FROM #TempUser (NOLOCK));
   
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
    FROM        #TempUser TU (NOLOCK)
    ORDER BY    TU.Created
    OFFSET      (@PAGE_NUMBER - 1) * @PAGE_SIZE ROWS
    FETCH NEXT  @PAGE_SIZE ROWS ONLY
    
    DROP TABLE #TempUser
GO  
