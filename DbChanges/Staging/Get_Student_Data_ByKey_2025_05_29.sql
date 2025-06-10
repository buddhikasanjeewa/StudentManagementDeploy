/****** Object:  StoredProcedure [dbo].[Get_Student_Data_by_Key]    Script Date: 5/29/2025 9:54:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika Walpita
-- Create date: 2025-05-29
-- Description:	Get Student Personal data by key
-- =============================================
CREATE PROCEDURE [dbo].[Get_Student_Data_by_Key]
@uid uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    Select * from tblStudent_Personal where UId=@uid

END
GO