USE [EvolentHealthDB]
GO
/****** Object:  Table [dbo].[tbl_ContactDetails]    Script Date: 28-10-2019 3.19.50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ContactDetails](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNo] [varchar](50) NULL,
	[StatusMode] [bit] NULL,
 CONSTRAINT [PK_tbl_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_ContactDetails] ADD  CONSTRAINT [DF_tbl_ContactDetails_StatusMode]  DEFAULT ((1)) FOR [StatusMode]
GO
/****** Object:  StoredProcedure [dbo].[DeleteContactDetail]    Script Date: 28-10-2019 3.19.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteContactDetail]
@CId int
AS
BEGIN 
DELETE FROM tbl_ContactDetails 
WHERE ContactId=@CId
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllContactDetails]    Script Date: 28-10-2019 3.19.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllContactDetails]
AS
BEGIN 
SELECT * FROM tbl_ContactDetails 
END;
GO
/****** Object:  StoredProcedure [dbo].[GetContactDetailsById]    Script Date: 28-10-2019 3.19.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetContactDetailsById]
@CId int
AS
BEGIN 
SELECT ContactId, FirstName, LastName, Email, PhoneNo,StatusMode FROM tbl_ContactDetails 
WHERE ContactId=@CId
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertContactDetails]    Script Date: 28-10-2019 3.19.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertContactDetails]
@FName varchar(50),
@LName varchar(50),
@Email varchar(50),
@PhoneNo varchar(50)
AS
BEGIN 
INSERT INTO tbl_ContactDetails(FirstName,LastName,Email,PhoneNo) VALUES(@FName,@LName,@Email,@PhoneNo)
END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateContactDetails]    Script Date: 28-10-2019 3.19.51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateContactDetails]
@CId int,
@FName varchar(50),
@LName varchar(50),
@Email varchar(50),
@PhoneNo varchar(50),
@StatusMode bit
AS
BEGIN 
UPDATE tbl_ContactDetails 
SET FirstName=@FName,LastName=@LName,Email=@Email,PhoneNo=@PhoneNo,StatusMode=@StatusMode
WHERE ContactId=@CId
END;
GO
