/****** Object:  StoredProcedure [dbo].[Save_Student_Personal_Data]    Script Date: 5/29/2025 9:54:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Buddhika Walpita
-- Create date: 2025-05-29
-- Description:	Insert Update Data
-- =============================================
CREATE PROCEDURE [dbo].[Save_Student_Personal_Data]
	-- Add the parameters for the stored procedure here
     @Uid uniqueidentifier,
	 @First_Name varchar(50),
	 @Last_Name varchar(50),
	 @Mobile varchar(20),
	 @Email varchar(50),
	 @NIC varchar(20),
	 @Dob date,
	 @Address varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF Exists(Select UID FROM tblStudent_Personal Where UID=@UID)-- Check Wehter record already exists
	   Begin  --Update Data
	    UPDATE [dbo].[tblStudent_Personal]
        SET [First_Name] = @First_Name
		  ,[Last_Name] = @Last_Name
		  ,[Mobile] = @Mobile
		  ,[Email] = @Email
		  ,[NIC] = @NIC
		  ,[DOB] = @Dob
		  ,[Address] =@Address
        WHERE UID=@Uid   
	   End
	   ELSE
	     
INSERT INTO [dbo].[tblStudent_Personal]
           ([UId]
           ,[First_Name]
           ,[Last_Name]
           ,[Mobile]
           ,[Email]
           ,[NIC]
           ,[DOB]
           ,[Address])
     VALUES
           (@Uid
           ,@First_Name
           ,@Last_Name
           ,@Mobile
           ,@Email
           ,@NIC
           ,@Dob
           ,@Address)
	  

END
GO
USE [master]
GO
ALTER DATABASE [SofttOneSMSNew] SET  READ_WRITE 
GO