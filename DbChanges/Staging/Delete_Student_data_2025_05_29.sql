/****** Object:  StoredProcedure [dbo].[Delete_Student_Data]    Script Date: 5/29/2025 9:54:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika Walpita
-- Create date: 2025-05-29
-- Description:	Delete Student data
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Student_Data]
	-- Add the parameters for the stored procedure here
	@Uid uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    Delete from tblStudent_Personal where UId=@UID
END
GO