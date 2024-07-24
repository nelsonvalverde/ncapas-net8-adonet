/*
    Responsable : Nelson Valverde La Torre
    Date        : 08/06/2024
    Description : Update status user
*/
CREATE PROCEDURE [dbo].[PROJ_UPDATE_USER_STATUS_SP]
    @ID                 VARCHAR(254),
    @STATUS_ID          TINYINT,
    @LAST_MODIFIED      DATETIME,
    @LAST_MODIFIED_BY   VARCHAR(60) 

    AS
    SET NOCOUNT ON;

    UPDATE  [dbo].[User]
    SET     [StatusId] = @STATUS_ID,
            [LastModified] = @LAST_MODIFIED,
            [LastModifiedBy] = @LAST_MODIFIED_BY
    WHERE   [Id] = @ID
     
GO  