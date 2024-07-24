/*
    Responsable : Nelson Valverde La Torre
    Date        : 08/06/2024
    Description : Update user
*/

CREATE PROCEDURE [dbo].[PROJ_UPDATE_USER_SP]
    @ID                 VARCHAR(254),
    @NAME               VARCHAR(60),
    @LAST_NAME          VARCHAR(60),
    @BIRTHDAY           DATE,
    @LAST_MODIFIED      DATETIME,
    @LAST_MODIFIED_BY   VARCHAR(60) 

    AS
    SET NOCOUNT ON;

    UPDATE  [dbo].[User]
    SET     [Name] = @NAME,
            [LastName] = @LAST_NAME,
            [Birthday] = @BIRTHDAY,
            [LastModified] = @LAST_MODIFIED,
            [LastModifiedBy] = @LAST_MODIFIED_BY
    WHERE   [Id] = @ID
     
GO  
