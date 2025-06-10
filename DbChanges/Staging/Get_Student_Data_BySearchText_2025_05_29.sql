USE [SofttOneSMSNew]
GO
/****** Object:  StoredProcedure [dbo].[Get_Student_Data_by_Search]    Script Date: 5/29/2025 6:15:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika Walpita
-- Create date: 2025-05-29
-- Description:	Get Student Personal data by Search Criteria
-- =============================================
ALTER PROCEDURE [dbo].[Get_Student_Data_by_Search]
@search varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    Select * from tblStudent_Personal where (First_Name like '' +@search+ '%') or ( Last_Name like '' +@search+ '%' ) 
or ( Mobile like '' +@search+ '%' )  or (Email like '' +@search+ '%') or (NIC like '' +@search+ '%')

END
