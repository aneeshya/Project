USE [Employeedb]
GO

/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 16-07-2024 01:02:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddEmployee]
	@Name nvarchar(50),@Description nvarchar(Max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Employeetbl(Name,Description) VALUES(@Name,@Description)
END
GO

