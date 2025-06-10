CREATE TABLE [dbo].[tblStudent_Personal](
	[UId] [uniqueidentifier] NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[Mobile] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[NIC] [varchar](20) NOT NULL,
	[DOB] [date] NULL,
	[Address] [varchar](250) NULL,
 CONSTRAINT [PK_tblStudent_Personal] PRIMARY KEY CLUSTERED 
(
	[UId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO