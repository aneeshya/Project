USE [Employeedb]
GO

/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 16-07-2024 01:03:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEmployee] @ID INT
AS
BEGIN
	
	SET NOCOUNT ON;

     Delete  FROM Employeetbl WHERE ID=@ID;
END
GO

