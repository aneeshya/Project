USE [Employeedb]
GO

/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 16-07-2024 01:06:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEmployee] 
	@Name nvarchar(50),@Description nvarchar(MAX),@ID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   UPDATE Employeetbl SET  Name=@Name,Description=@Description WHERE ID=@ID
END
GO

