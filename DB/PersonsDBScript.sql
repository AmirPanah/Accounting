USE [PersonsDB]
GO
/****** Object:  Schema [HR]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
CREATE SCHEMA [HR]
GO
/****** Object:  Table [dbo].[CM]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CM](
	[receive_fromnumber] [nvarchar](255) NULL,
	[receive_message] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Emps]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emps](
	[phon] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[Departments]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[EduFields]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[EduFields](
	[FieldID] [int] IDENTITY(1,1) NOT NULL,
	[FieldTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_EduFields] PRIMARY KEY CLUSTERED 
(
	[FieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[EduLevels]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[EduLevels](
	[LevelID] [int] IDENTITY(1,1) NOT NULL,
	[LevelTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_EduLevels] PRIMARY KEY CLUSTERED 
(
	[LevelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[EduTendencies]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[EduTendencies](
	[TendencyID] [int] IDENTITY(1,1) NOT NULL,
	[FieldID] [int] NULL,
	[TendencyTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_EduTendencies] PRIMARY KEY CLUSTERED 
(
	[TendencyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[EmailContacts]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[EmailContacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NULL,
	[UserID] [int] NULL,
	[EmailTypeID] [int] NULL,
	[EmailAddrress] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmailContacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[EmailTypes]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[EmailTypes](
	[EmailTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EmailTypeTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmailTypes] PRIMARY KEY CLUSTERED 
(
	[EmailTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[Employees]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NULL,
	[RoleID] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[NationalCode] [nvarchar](10) NULL,
	[ImageFileName] [nvarchar](150) NULL,
	[FixTel] [nvarchar](50) NULL,
	[Mobile] [nvarchar](11) NULL,
	[Email] [nvarchar](150) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Emloyees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[Faculties]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Faculties](
	[FacultyID] [int] IDENTITY(1,1) NOT NULL,
	[FacultyTitle] [nvarchar](60) NULL,
 CONSTRAINT [PK_Facultyies] PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[Lecturers]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Lecturers](
	[LecturerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[NationalCode] [nvarchar](10) NULL,
	[ImageFileName] [nvarchar](150) NULL,
	[FixTel] [nvarchar](50) NULL,
	[Mobile] [nvarchar](11) NULL,
	[Email] [nvarchar](150) NULL,
	[FacultyID] [int] NULL,
	[FieldID] [int] NULL,
	[TendencyID] [int] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Lecturers] PRIMARY KEY CLUSTERED 
(
	[LecturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[PersonsAdmins]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[PersonsAdmins](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_PersonsAdmins] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[Roles]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[Students]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentCode] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NULL,
	[NationalCode] [nvarchar](10) NULL,
	[ImageFileName] [nvarchar](150) NULL,
	[FixTel] [nvarchar](50) NULL,
	[Mobile] [nvarchar](11) NULL,
	[Email] [nvarchar](150) NULL,
	[FacultyID] [int] NULL,
	[LevelID] [int] NULL,
	[FieldID] [int] NULL,
	[TendencyID] [int] NULL,
	[EntryTerm] [int] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](150) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[TelContacts]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[TelContacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NULL,
	[UserID] [int] NULL,
	[TelTypeID] [int] NULL,
	[TelNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_TelContacts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[TelTypes]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[TelTypes](
	[TelTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TelTypeTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_TelTypes] PRIMARY KEY CLUSTERED 
(
	[TelTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [HR].[VPNs]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[VPNs](
	[VPNID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeID] [int] NULL,
	[UserID] [int] NULL,
	[DepartmentID] [int] NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[VPNDescription] [ntext] NULL,
 CONSTRAINT [PK_VPNS] PRIMARY KEY CLUSTERED 
(
	[VPNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [HR].[WebServiceAccount]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [HR].[WebServiceAccount](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_WebServiceAccount] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[VEduTendencies]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VEduTendencies]
AS
SELECT     HR.EduTendencies.TendencyID, HR.EduTendencies.FieldID, HR.EduTendencies.TendencyTitle, HR.EduFields.FieldTitle
FROM         HR.EduTendencies LEFT OUTER JOIN
                      HR.EduFields ON HR.EduTendencies.FieldID = HR.EduFields.FieldID




GO
/****** Object:  View [dbo].[VEmailContacts]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VEmailContacts]
AS
SELECT     HR.EmailContacts.ID, HR.EmailContacts.UserTypeID, HR.EmailContacts.UserID, HR.EmailContacts.EmailTypeID, HR.EmailContacts.EmailAddrress, 
                      HR.EmailTypes.EmailTypeTitle
FROM         HR.EmailContacts LEFT OUTER JOIN
                      HR.EmailTypes ON HR.EmailContacts.EmailTypeID = HR.EmailTypes.EmailTypeID




GO
/****** Object:  View [dbo].[VEmployees]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VEmployees]
AS
SELECT        HR.Employees.EmployeeID, HR.Employees.DepartmentID, HR.Departments.DepartmentTitle, HR.Employees.RoleID, HR.Roles.RoleTitle, HR.Employees.FirstName, 
                         HR.Employees.LastName, HR.Employees.Gender, HR.Employees.NationalCode, HR.Employees.ImageFileName, HR.Employees.FixTel, HR.Employees.Mobile, 
                         HR.Employees.Email, HR.Employees.Username, HR.Employees.Password, HR.Employees.Status
FROM            HR.Employees LEFT OUTER JOIN
                         HR.Departments ON HR.Employees.DepartmentID = HR.Departments.DepartmentID LEFT OUTER JOIN
                         HR.Roles ON HR.Employees.RoleID = HR.Roles.RoleID

GO
/****** Object:  View [dbo].[VLecturers]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VLecturers]
AS
SELECT     HR.Lecturers.LecturerID, HR.Lecturers.FirstName, HR.Lecturers.LastName, HR.Lecturers.Gender, HR.Lecturers.NationalCode, HR.Lecturers.ImageFileName, 
                      HR.Lecturers.Mobile, HR.Lecturers.FixTel, HR.Lecturers.Email, HR.Lecturers.FacultyID, HR.Lecturers.FieldID, HR.Lecturers.Username, HR.Lecturers.TendencyID, 
                      HR.Lecturers.Password, HR.Lecturers.Status, HR.Faculties.FacultyTitle, HR.EduFields.FieldTitle, HR.EduTendencies.TendencyTitle
FROM         HR.Lecturers LEFT OUTER JOIN
                      HR.Faculties ON HR.Lecturers.FacultyID = HR.Faculties.FacultyID LEFT OUTER JOIN
                      HR.EduFields ON HR.Lecturers.FieldID = HR.EduFields.FieldID LEFT OUTER JOIN
                      HR.EduTendencies ON HR.Lecturers.TendencyID = HR.EduTendencies.TendencyID




GO
/****** Object:  View [dbo].[VStudents]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VStudents]
AS
SELECT     HR.Students.StudentID, HR.Students.StudentCode, HR.Students.FirstName, HR.Students.LastName, HR.Students.Gender, HR.Students.NationalCode, 
                      HR.Students.ImageFileName, HR.Students.FixTel, HR.Students.Mobile, HR.Students.Email, HR.Students.FacultyID, HR.Students.LevelID, HR.Students.FieldID, 
                      HR.Students.TendencyID, HR.Students.EntryTerm, HR.Students.Username, HR.Students.Password, HR.Students.Status, HR.Faculties.FacultyTitle, 
                      HR.EduLevels.LevelTitle, HR.EduFields.FieldTitle, HR.EduTendencies.TendencyTitle
FROM         HR.Students LEFT OUTER JOIN
                      HR.Faculties ON HR.Students.FacultyID = HR.Faculties.FacultyID LEFT OUTER JOIN
                      HR.EduLevels ON HR.Students.LevelID = HR.EduLevels.LevelID LEFT OUTER JOIN
                      HR.EduFields ON HR.Students.FieldID = HR.EduFields.FieldID LEFT OUTER JOIN
                      HR.EduTendencies ON HR.Students.TendencyID = HR.EduTendencies.TendencyID




GO
/****** Object:  View [dbo].[VTelContacts]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VTelContacts]
AS
SELECT     HR.TelContacts.ID, HR.TelContacts.UserTypeID, HR.TelContacts.UserID, HR.TelContacts.TelTypeID, HR.TelContacts.TelNumber, HR.TelTypes.TelTypeTitle
FROM         HR.TelContacts LEFT OUTER JOIN
                      HR.TelTypes ON HR.TelContacts.TelTypeID = HR.TelTypes.TelTypeID




GO
/****** Object:  View [dbo].[VVPNs]    Script Date: 01/19/2016 12:14:09 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VVPNs]
AS
SELECT        HR.VPNS.VPNID, HR.VPNS.UserTypeID, HR.VPNS.UserID, HR.VPNS.DepartmentID, HR.VPNS.Username, HR.VPNS.Password, HR.VPNS.VPNDescription, 
                         HR.Departments.DepartmentID AS Expr1, HR.Departments.DepartmentTitle
FROM            HR.VPNS LEFT OUTER JOIN
                         HR.Departments ON HR.VPNS.DepartmentID = HR.Departments.DepartmentID

GO
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112534089', N'2063051003')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09126584855', N'2092295659')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111230702', N'4898456642')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111588632', N'2092067370')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113560540', N'2140197811')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111514422', N'0045584214')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09338977615', N'2161969781')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111539885', N'2061175880')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111160613', N'2061155057')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112540339', N'2091950750')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09199514401', N'2091172065 ')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09370020838', N'5829126941')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09305684368', N'2161435094')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113557763', N'5418988158')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111565342', N'0924295457')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112531473', N'2121543376')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112233515', N'2161820605')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09114468188', N'2161852183')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111589038', N'2092084917')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113544044', N'2092853953')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09118510662', N'2093225891')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112542733', N'2090213086')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111539366', N'2092989596')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112127410', N'4989916433')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111523273', N'4608930850')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09119231070', N'5829793377')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09378828476', N'5789631924')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113262260', N'5829769761')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09119591680', N'0069737584')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113581800', N'2279681188')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112530969', N'2162204533')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112564965', N'0043931324')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113546935', N'2092052837')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113147929', N'0040219712')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113513159', N'2121382534')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112510886', N'2091966010')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111147563', N'2142070711')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112539964', N'2259436129')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112565375', N'5829658747')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112528544', N'2160073121')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09119545328', N'2162331209')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113539217', N'0064943488')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111569182', N'2092144103')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111285979', N'2161719394')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09123196445', N'2161928384')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111583121', N'2092636413')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113532904', N'2181808163')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111280717', N'2161961586')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113123118', N'6319806214')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09378007407', N'0070235899')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112528543', N'2092902369')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112541708', N'2092364936')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111280717', N'2161961586')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113535909', N'5799939026')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112548654', N'2092055951')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09112529658', N'2092203630')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113231731', N'2259668054')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09113532397', N'2181310149')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09118545931', N'2063116113')
INSERT [dbo].[CM] ([receive_fromnumber], [receive_message]) VALUES (N'09111583121', N'2092636413')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111522131', N'محمد تقی هدایتی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112548654', N'نازنین لطفی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111230702', N'فرهنگ بابا محمودی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09118545931', N'فاطمه آهنگرکانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111510396', N'زهرا کاشی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111245156', N'عذرا اخی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113581800', N'لیلا اسدیان')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09118510662', N'فاخره قربانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111514422', N'مهران ضرغامی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111523273', N'جواد ستاره')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111135010', N'مهدی پور اصغر')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113539217', N'فاطمه شیخ مونسی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112529658', N'مائده واقفی نژاد')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113147929', N'سوسن سالاری')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113549100', N'لیلا شهباز نژاد')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111539366', N'سهیلا شاه محمدی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09119231070', N'لیلا سرپرست')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09338977615', N'سارا اسد پور')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111539828', N'آزیتا صدوق')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'0', N'تصفیه')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'0', N'زهرا بخشی کیادهی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112127410', N'جواد حسن زاده')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09374537571', N'زینب محمدی تلارمی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113236290', N'بتول رحیمی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111513027', N'سید عبدالله مدنی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111519304', N'مهرنوش کوثریان')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112233515', N'آیلی علی اصغریان')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111285979', N'سید معصومه موسوی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09369611374', N'حسین جلالی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112541708', N'سید مهسا علوی اندراجمی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112528543', N'حامد فتحی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111563618', N'حامد مراد')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'0', N'احمد بخرد نیا')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112561480', N'فریده رستمی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113231731', N'قاسم عابدی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111523025', N'بهزاد نیک پور')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111160613', N'علی نادی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111533013', N'تورج فرازمندفر')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111588632', N'زهرا حسینی خواه')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113532397', N'رمیسا شهربافی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113535909', N'رضوان خوجوی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112542733', N'نوروز عاشق نوا')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111280717', N'بهار ابراهیم مقام')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111550535', N'سیده فاطمه موسوی کنتی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112565375', N'فرشته مطلبی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113262260', N'بتول رمضانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113557763', N'علیرضا رفیعی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09114468188', N'اسماعیل ذکریایی تلوکی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09384353828', N'مهدی حمیدی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113544044', N'مسلم فهیمی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09119591680', N'سکینه فرامرزی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111522209', N'احمد علی عنایتی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111551097', N'فروزان الیاسی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112561816', N'علی اصغر میرزایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09127615950', N'پوریا گیل')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113548271', N'میران عنایتی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111583121', N'حمید رضا آذرفر')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112564965', N'محسن اعرابی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113913789', N'بهاره موید احمدی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111533451', N'احمد تقی زاده')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112247303', N'سید احمد نوربخش')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09378828476', N'اکرم ذلیکانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111581986', N'آسیه یوسفی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09123196445', N'مریم افرادی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113532904', N'مریم قاجار کوهستانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112567050', N'منا مختارپور')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09119545328', N'حسین عزیزی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112534089', N'سمیه قنبری نودهی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09123989651', N'بهنام غفاری چراتی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111147563', N'رضا علیزاده نوایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112134939', N'محمد رضا حق شناس')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09126584855', N'عاتکه هادی نژاد ماکرانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113536575', N'تقی غلامی میارکلایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113534917', N'سید محمود کاظم نژاد')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113560540', N'جواد اکبر زاده')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113123118', N'زهره افشار')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09370020838', N'سیما عباسی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113502412', N'سیده فاطمه موسوی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09199514401', N'ابراهیم اسماعیلی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112544933', N'منیره شیروانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09366776234', N'محمد شیرزاد')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112545144', N'طهورا موسوی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113544170', N'شیدا.. آهنگری')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111582076', N'مجید صفاجو')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111569182', N'صفورا معصومی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09378007407', N'نعیم یوسفی فرد')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112540339', N'مجتبی شیروانی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113533953', N'شیده انوری')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113512474', N'محمد باقر منتظری')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113546935', N'زهره تقی زاده')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112531473', N'مریم شهابی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09118905245', N'راحله اسماعیل نیا')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113239409', N'سامره فلاح پور')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111589038', N'زهرا فروغی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09113513159', N'مهرنوش عالیشاه')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111551102', N'محمد صادق رضایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112539964', N'مصطفی عطایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09374786837', N'مجید بخشایش')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09366803238', N'مطهره خردمند')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111150151', N'هوشنگ علی اصغری جلودار زاده')
GO
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112528754', N'ولی ا.. احمدی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111565342', N'اسماء عرفایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111564220', N'انسیه تقی زاده')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111539885', N'رمضانعلی بابایی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09391276662', N'سید باجی صالحی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112510886', N'علیرضا نوپور')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112530969', N'فاطمه قدمی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111170942', N'ارس اکبر نتاج')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09111589914', N'لیلا شکوهی')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112528544', N'رقیه صفری')
INSERT [dbo].[Emps] ([phon], [name]) VALUES (N'09112238568', N'مریم جوادیان')
SET IDENTITY_INSERT [HR].[Departments] ON 

INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (1, N'IT')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (2, N'آزمایشگاه جامع تحقیقاتی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (3, N'اداره پژوهشی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (4, N'اداره سمینار و کنگره ها')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (5, N'امور عمومی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (6, N'انتشارات')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (7, N'موسسه تحقیقات حیوانات آزمایشگاهی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (8, N'پایش و ارزشیابی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (9, N'توانمند سازی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (10, N'دبيرخانه')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (11, N'دفتر مجله')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (12, N'امور مالی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (13, N'واحد مرکز تحقيقاتی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (14, N'مرکز تحقیقات  ارتوپدی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (15, N'مرکز تحقیقات  بيولوژي سلولي و مولكولي')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (16, N'مرکز تحقیقات  بیماریهای عفونی اطفال')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (17, N'مرکز تحقیقات  بیماریهای گوارش و کبد')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (18, N'مرکز تحقیقات  تالاسمي')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (19, N'مرکز تحقیقات  توکسوپلاسموزیس')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (20, N'مرکز تحقیقات  دیابت ')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (21, N'مرکز تحقیقات  روانپزشكي و علوم رفتاري')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (22, N'مرکز تحقیقات  ژنتیک ایمنی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (23, N'مرکز تحقیقات  سرطان دستگاه گوارش')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (24, N'مرکز تحقیقات  سلامت فراورده های گیاهی و دامی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (25, N'مرکز تحقیقات  طب سنتي و مكمل')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (26, N'مرکز تحقیقات  علوم بهداشتی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (27, N'مرکز تحقیقات  علوم دارويي')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (28, N'مرکز تحقیقات  قارچ های تهاجمی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (29, N'مرکز تحقیقات  قلب و عروق')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (30, N'مرکز تحقیقات  مقاومتهای میکروبی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (31, N'مرکز رشد')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (32, N'کارپردازی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (33, N'کارشناسان پژوهشی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (34, N'کتابخانه')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (35, N'کميته انضباتی')
INSERT [HR].[Departments] ([DepartmentID], [DepartmentTitle]) VALUES (36, N'کميته تحقيقات دانشجويی')
SET IDENTITY_INSERT [HR].[Departments] OFF
SET IDENTITY_INSERT [HR].[EduFields] ON 

INSERT [HR].[EduFields] ([FieldID], [FieldTitle]) VALUES (5, N'بهداشت')
INSERT [HR].[EduFields] ([FieldID], [FieldTitle]) VALUES (6, N'پزشکی')
SET IDENTITY_INSERT [HR].[EduFields] OFF
SET IDENTITY_INSERT [HR].[EduLevels] ON 

INSERT [HR].[EduLevels] ([LevelID], [LevelTitle]) VALUES (10, N'کاردانی')
INSERT [HR].[EduLevels] ([LevelID], [LevelTitle]) VALUES (11, N'کارشناسی')
INSERT [HR].[EduLevels] ([LevelID], [LevelTitle]) VALUES (13, N'دکتری')
INSERT [HR].[EduLevels] ([LevelID], [LevelTitle]) VALUES (14, N'dfsdf')
INSERT [HR].[EduLevels] ([LevelID], [LevelTitle]) VALUES (15, N'dfgdgdg')
INSERT [HR].[EduLevels] ([LevelID], [LevelTitle]) VALUES (16, N'dsfsdg')
SET IDENTITY_INSERT [HR].[EduLevels] OFF
SET IDENTITY_INSERT [HR].[EduTendencies] ON 

INSERT [HR].[EduTendencies] ([TendencyID], [FieldID], [TendencyTitle]) VALUES (16, 6, N'er')
SET IDENTITY_INSERT [HR].[EduTendencies] OFF
SET IDENTITY_INSERT [HR].[EmailContacts] ON 

INSERT [HR].[EmailContacts] ([ID], [UserTypeID], [UserID], [EmailTypeID], [EmailAddrress]) VALUES (1, 1, 12, 1, N'sda@y')
SET IDENTITY_INSERT [HR].[EmailContacts] OFF
SET IDENTITY_INSERT [HR].[EmailTypes] ON 

INSERT [HR].[EmailTypes] ([EmailTypeID], [EmailTypeTitle]) VALUES (1, N'nhdfgd')
INSERT [HR].[EmailTypes] ([EmailTypeID], [EmailTypeTitle]) VALUES (2, N'سازمانی')
INSERT [HR].[EmailTypes] ([EmailTypeID], [EmailTypeTitle]) VALUES (3, N'gmail')
SET IDENTITY_INSERT [HR].[EmailTypes] OFF
SET IDENTITY_INSERT [HR].[Employees] ON 

INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (1, NULL, NULL, N'زهره ', N'افشار', NULL, N'6319806214', N'', NULL, N'09113123118', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (2, NULL, NULL, N'لیلا ', N'سرپرست', NULL, N'5829793377', N'', NULL, N'09119231070', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (3, NULL, NULL, N'بتول ', N'رمضانی', NULL, N'5829769761', N'', NULL, N'09113262260', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (4, NULL, NULL, N'فرشته ', N'مطلبی', NULL, N'5829658747', N'', NULL, N'09112565375', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (5, NULL, NULL, N'سیما ', N'عباسی', NULL, N'5829126941', N'', NULL, N'09370020838', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (6, NULL, NULL, N'رضوان ', N'خواجوی', NULL, N'5799939026', N'', NULL, N'09113535909', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (7, NULL, NULL, N'اکرم ', N'ذلیکانی', NULL, N'5789631924', N'', NULL, N'09378828476', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (8, NULL, NULL, N'علیرضا ', N'رفیعی', NULL, N'5418988158', N'', NULL, N'09113557763', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (9, NULL, NULL, N'جواد ', N'حسن زاده', NULL, N'4989916433', N'', NULL, N'09112127410', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (10, NULL, NULL, N'فرهنگ ', N'بابا محمودی', NULL, N'4898456642', N'', NULL, N'09111230702', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (11, NULL, NULL, N'جواد ', N'ستاره', NULL, N'4608930850', N'', NULL, N'09111523273', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (12, NULL, NULL, N'لیلا ', N'اسدیان', NULL, N'2279681188', N'', NULL, N'09113581800', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (13, NULL, NULL, N'قاسم ', N'عابدی', NULL, N'2259668054', N'', NULL, N'09113231731', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (14, NULL, NULL, N'مصطفی ', N'عطایی', NULL, N'2259436129', N'', NULL, N'09112539964', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (15, NULL, NULL, N'مریم ', N'قاجار کوهستانی', NULL, N'2181808163', N'', NULL, N'09113532904', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (16, NULL, NULL, N'رمیسا ', N'شهربافی', NULL, N'2181310149', N'', NULL, N'09113532397', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (17, NULL, NULL, N'حسین ', N'عزیزی', NULL, N'2162331209', N'', NULL, N'09119545328', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (18, NULL, NULL, N'فاطمه ', N'قدمی', NULL, N'2162204533', N'', NULL, N'09112530969', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (19, NULL, NULL, N'سارا ', N'اسد پور', NULL, N'2161969781', N'', NULL, N'09338977615', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (20, NULL, NULL, N'بهار ', N'ابراهیم مقام', NULL, N'2161961586', N'', NULL, N'09111280717', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (21, NULL, NULL, N'مریم ', N'افرادی', NULL, N'2161928384', N'', NULL, N'09123196445', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (22, NULL, NULL, N'اسماعیل ', N'ذکریایی تلوکی', NULL, N'2161852183', N'', NULL, N'09114468188', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (23, NULL, NULL, N'آیلی ', N'علی اصغریان', NULL, N'2161820605', N'', NULL, N'09112233515', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (24, NULL, NULL, N'سید معصومه', N'موسوی', NULL, N'2161719394', N'', NULL, N'09111285979', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (25, NULL, NULL, N'رقیه ', N'صفری', NULL, N'2160073121', N'', NULL, N'09112528544', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (26, NULL, NULL, N'رضا ', N'علیزاده نوایی', NULL, N'2142070711', N'', NULL, N'09111147563', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (27, NULL, NULL, N'جواد ', N'اکبر زاده', NULL, N'2140197811', N'', NULL, N'09113560540', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (28, NULL, NULL, N'مریم ', N'شهابی', NULL, N'2121543376', N'', NULL, N'09112531473', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (29, NULL, NULL, N'مهرنوش ', N'عالیشاه', NULL, N'2121382534', N'', NULL, N'09113513159', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (30, NULL, NULL, N'فاخره ', N'قربانی', NULL, N'2093225891', N'', NULL, N'09118510662', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (31, NULL, NULL, N'سهیلا ', N'شاه محمدی', NULL, N'2092989596', N'', NULL, N'09111539366', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (32, NULL, NULL, N'حامد ', N'فتحی', NULL, N'2092902369', N'', NULL, N'09112528543', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (33, NULL, NULL, N'مسلم ', N'فهیمی', NULL, N'2092853953', N'', NULL, N'09113544044', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (34, NULL, NULL, N'حمیدرضا', N'آذرفر', NULL, N'2092636413', N'', NULL, N'09111583121', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (35, NULL, NULL, N'سیده مهسا', N'علوی اندراجمی', NULL, N'2092364936', N'', NULL, N'09112541708', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (36, NULL, NULL, N'عاتکه ', N'هادی نژاد ماکرانی', NULL, N'2092295659', N'', NULL, N'09126584855', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (37, NULL, NULL, N'مائده ', N'واقفی نژاد', NULL, N'2092203630', N'', NULL, N'09112529658', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (38, NULL, NULL, N'صفورا ', N'معصومی', NULL, N'2092144103', N'', NULL, N'09111569182', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (39, NULL, NULL, N'زهرا ', N'فروغی', NULL, N'2092084917', N'', NULL, N'09111589038', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (40, NULL, NULL, N'زهرا ', N'حسینی خواه', NULL, N'2092067370', N'', NULL, N'09111588632', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (41, NULL, NULL, N'نازنین ', N'لطفی', NULL, N'2092055951', N'', NULL, N'09112548654', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (42, NULL, NULL, N'زهره ', N'تقی زاده', NULL, N'2092052837', N'', NULL, N'09113546935', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (43, NULL, NULL, N'علیرضا ', N'نوپور', NULL, N'2091966010', N'', NULL, N'09112510886', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (44, NULL, NULL, N'مجتبی ', N'شیروانی', NULL, N'2091950750', N'', NULL, N'09112540339', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (45, NULL, NULL, N'ابراهیم ', N'اسماعیلی', NULL, N'2091172065', N'', NULL, N'09199514401', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (46, NULL, NULL, N'نوروز ', N'عاشق نوا', NULL, N'2090213086', N'', NULL, N'09112542733', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (47, NULL, NULL, N'فاطمه ', N'آهنگرکانی', NULL, N'2063116113', N'', NULL, N'09118545931', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (48, NULL, NULL, N'سمیه ', N'قنبری نودهی', NULL, N'2063051003', N'', NULL, N'09112534089', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (49, NULL, NULL, N'رمضانعلی ', N'بابایی', NULL, N'2061175880', N'', NULL, N'09111539885', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (50, NULL, NULL, N'علی ', N'نادی', NULL, N'2061155057', N'', NULL, N'09111160613', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (51, NULL, NULL, N'اسماء ', N'عرفایی', NULL, N'0924295457', N'', NULL, N'09111565342', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (52, 1, 7, N'نعیم ', N'یوسفی فرد', 1, N'0070235899', N'NYF_2015104_234524236.jpg', N'01133044800', N'09378007407', N'iritman@gmail.com', NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (53, NULL, NULL, N'سکینه ', N'فرامرزی', NULL, N'0069737584', N'', NULL, N'09119591680', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (54, NULL, NULL, N'فاطمه ', N'شیخ مونسی', NULL, N'0064943488', N'', NULL, N'09113539217', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (55, NULL, NULL, N'مهران ', N'ضرغامی', NULL, N'0045584214', N'', NULL, N'09111514422', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (56, NULL, NULL, N'محسن ', N'اعرابی', NULL, N'0043931324', N'', NULL, N'09112564965', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (57, NULL, NULL, N'سوسن ', N'سالاری', NULL, N'0040219712', N'', NULL, N'09113147929', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (59, NULL, NULL, N'مهدی ', N'پور اصغر', NULL, NULL, N'', NULL, N'09111135010', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (60, NULL, NULL, N'آزیتا ', N'صدوق', NULL, N'0055216838', N'', NULL, N'09111539828', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (62, NULL, NULL, N'زهرا ', N'بخشی کیادهی', NULL, N'2259717071', N'', NULL, N'0', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (63, NULL, NULL, N'محمد تقی', N'هدایتی', NULL, N'6259861621', N'', NULL, N'09111522131', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (64, NULL, NULL, N'زهرا ', N'کاشی', NULL, N'0037116533', N'', NULL, N'09111510396', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (67, NULL, NULL, N'زینب ', N'محمدی تلارمی', NULL, NULL, N'', NULL, N'09374537571', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (68, NULL, NULL, N'بتول ', N'رحیمی', NULL, N'2161477935', N'', NULL, N'09113236290', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (69, NULL, NULL, N'سید عبدالله', N'مدنی', NULL, N'2180949073', N'', NULL, N'09111513027', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (70, NULL, NULL, N'مهرنوش ', N'کوثریان', NULL, N'2290923966', N'', NULL, N'09111519304', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (71, NULL, NULL, N'تورج ', N'فرازمندفر', NULL, N'2121478647', N'', NULL, N'09111533013', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (72, NULL, NULL, N'بهزاد ', N'نیک پور', NULL, N'2181093008', N'', NULL, N'09111523025', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (75, NULL, NULL, N'فریده ', N'رستمی', NULL, N'2093054647', N'', NULL, N'09112561480', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (78, NULL, NULL, N'سید احمد', N'نوربخش', NULL, N'5829073684', N'', NULL, N'09112247303', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (79, NULL, NULL, N'منا ', N'مختارپور', NULL, N'2093630117', N'', NULL, N'09112567050', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (80, NULL, NULL, N'آسیه ', N'یوسفی', NULL, N'5829432935', N'', NULL, N'09111581986', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (81, NULL, NULL, N'بهنام ', N'غفاری چراتی', NULL, N'2161692771', N'', NULL, N'09123989651', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (83, NULL, NULL, N'تقی ', N'غلامی میارکلایی', NULL, N'2092861026', N'', NULL, N'09113536575', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (84, NULL, NULL, N'سید محمود', N'کاظم نژاد', NULL, N'2181129088', N'', NULL, N'09113534917', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (85, NULL, NULL, N'احمد علی', N'عنایتی', NULL, NULL, N'', NULL, N'09111522209', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (87, NULL, NULL, N'علی اصغر', N'میرزایی', NULL, NULL, N'', NULL, N'09112561816', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (88, NULL, NULL, N'پوریا ', N'گیل', NULL, N'0064169782', N'', NULL, N'09127615950', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (90, NULL, NULL, N'مهدی ', N'حمیدی', NULL, NULL, N'', NULL, N'09384353828', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (91, NULL, NULL, N'سیده فاطمه', N'موسوی کنتی', NULL, N'2180314248', N'', NULL, N'09111550535', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (92, NULL, NULL, N'سیده فاطمه', N'موسوی', NULL, N'2091955876', N'', NULL, N'09113502412', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (93, NULL, NULL, N'منیره ', N'شیروانی', NULL, N'2092051172', N'', NULL, N'09112544933', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (94, NULL, NULL, N'محمد ', N'شیرزاد', NULL, N'2229491733', N'', NULL, N'09366776234', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (95, NULL, NULL, N'طهورا ', N'موسوی', NULL, N'2200533349', N'', NULL, N'09112545144', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (96, NULL, NULL, N'شیدا.. ', N'آهنگری', NULL, N'5829458993', N'', NULL, N'09113544170', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (97, NULL, NULL, N'مجید ', N'صفاجو', NULL, N'2092400835', N'', NULL, N'09111582076', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (99, NULL, NULL, N'محمد باقر', N'منتظری', NULL, N'0383549604', N'', NULL, N'09113512474', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (100, NULL, NULL, N'راحله ', N'اسماعیل نیا', NULL, N'2063742391', N'', NULL, N'09118905245', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (101, NULL, NULL, N'سامره ', N'فلاح پور', NULL, N'2162612666', N'', NULL, N'09113239409', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (102, NULL, NULL, N'محمد صادق', N'رضایی', NULL, N'5829146381', N'', NULL, N'09111551102', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (105, NULL, NULL, N'مجید ', N'بخشایش', NULL, N'2092854445', N'', NULL, N'09374786837', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (106, NULL, NULL, N'مطهره ', N'خردمند', NULL, N'2161722824', N'', NULL, N'09112256368', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (107, NULL, NULL, N'هوشنگ ', N'علی اصغری جلودار زاده', NULL, N'2060801206', N'', NULL, N'09111150151', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (108, NULL, NULL, N'ولی ا..', N'احمدی', NULL, N'2161092014', N'', NULL, N'09112528754', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (109, NULL, NULL, N'مریم ', N'جوادیان', NULL, N'2161435094', N'', NULL, N'09112238568', NULL, NULL, NULL, NULL)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (110, 1, 1, N'erw', N'erwr', 1, N'32424', N'', NULL, NULL, NULL, N'ds', N'202CB962AC59075B964B07152D234B70', 0)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (1110, 1, 1, N'asda', N'asdas', 0, N'32254', N'', NULL, NULL, NULL, N'sa', N'202CB962AC59075B964B07152D234B70', 0)
INSERT [HR].[Employees] ([EmployeeID], [DepartmentID], [RoleID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [Username], [Password], [Status]) VALUES (2110, 1, 6, N'sasasa', N'fffff', 0, N'5285285285', N'139408061106111.png', N'3265985', N'09114564565', N'ad@yahoo.com', NULL, NULL, NULL)
SET IDENTITY_INSERT [HR].[Employees] OFF
GO
SET IDENTITY_INSERT [HR].[Faculties] ON 

INSERT [HR].[Faculties] ([FacultyID], [FacultyTitle]) VALUES (10, N'پیراپزشکی')
INSERT [HR].[Faculties] ([FacultyID], [FacultyTitle]) VALUES (11, N'دندانپزشکی')
SET IDENTITY_INSERT [HR].[Faculties] OFF
SET IDENTITY_INSERT [HR].[Lecturers] ON 

INSERT [HR].[Lecturers] ([LecturerID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [FacultyID], [FieldID], [TendencyID], [Username], [Password], [Status]) VALUES (3, N'استاد', N'ب', 0, N'3', N'', NULL, NULL, NULL, 10, 5, 14, N'ص', N'8CEBEA0BB022A92B5CAF8FED36A09439', 0)
INSERT [HR].[Lecturers] ([LecturerID], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [FacultyID], [FieldID], [TendencyID], [Username], [Password], [Status]) VALUES (5, N'er4e', N'wqeqe', 0, N'212123132', N'', NULL, NULL, NULL, 10, 5, 16, N'ww', N'202CB962AC59075B964B07152D234B70', 0)
SET IDENTITY_INSERT [HR].[Lecturers] OFF
SET IDENTITY_INSERT [HR].[PersonsAdmins] ON 

INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (2, N'admin', N'admin', N'sa', N'123', 0)
INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (3, N'ss', N'sderw', N'sa', N'123', 0)
INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (11, NULL, NULL, N'sadfasfs', N'8277E0910D750195B448797616E091AD', NULL)
INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (12, NULL, NULL, N'iuiu', N'202CB962AC59075B964B07152D234B70', NULL)
INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (13, N'o', N'o', N'ooo', N'202CB962AC59075B964B07152D234B70', NULL)
INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (14, N'i', N'i', N'tt', N'202CB962AC59075B964B07152D234B70', NULL)
INSERT [HR].[PersonsAdmins] ([AdminID], [FirstName], [LastName], [Username], [Password], [Status]) VALUES (15, N'o', N'o', N'oooop', N'202CB962AC59075B964B07152D234B70', 0)
SET IDENTITY_INSERT [HR].[PersonsAdmins] OFF
SET IDENTITY_INSERT [HR].[Roles] ON 

INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (1, N'معاون')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (2, N'مدیر پژوهشی')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (3, N'مدیر فناوری')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (4, N'مدیر اطلاع رسانی')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (5, N'رئیس مرکز')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (6, N'مسئول واحد')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (7, N'کارشناس')
INSERT [HR].[Roles] ([RoleID], [RoleTitle]) VALUES (8, N'کتابدار')
SET IDENTITY_INSERT [HR].[Roles] OFF
SET IDENTITY_INSERT [HR].[Students] ON 

INSERT [HR].[Students] ([StudentID], [StudentCode], [FirstName], [LastName], [Gender], [NationalCode], [ImageFileName], [FixTel], [Mobile], [Email], [FacultyID], [LevelID], [FieldID], [TendencyID], [EntryTerm], [Username], [Password], [Status]) VALUES (12, N'4444', N'تست', N'تستی', 0, N'22222', N'', NULL, NULL, NULL, 10, 10, 5, 14, 0, N'de', N'202CB962AC59075B964B07152D234B70', 0)
SET IDENTITY_INSERT [HR].[Students] OFF
SET IDENTITY_INSERT [HR].[TelContacts] ON 

INSERT [HR].[TelContacts] ([ID], [UserTypeID], [UserID], [TelTypeID], [TelNumber]) VALUES (3, 1, 12, 2, N'0911111111')
INSERT [HR].[TelContacts] ([ID], [UserTypeID], [UserID], [TelTypeID], [TelNumber]) VALUES (4, 1, 12, 2, N'453453453453')
INSERT [HR].[TelContacts] ([ID], [UserTypeID], [UserID], [TelTypeID], [TelNumber]) VALUES (5, 1, 12, 2, N'345345345')
SET IDENTITY_INSERT [HR].[TelContacts] OFF
SET IDENTITY_INSERT [HR].[TelTypes] ON 

INSERT [HR].[TelTypes] ([TelTypeID], [TelTypeTitle]) VALUES (2, N'موبایل')
SET IDENTITY_INSERT [HR].[TelTypes] OFF
SET IDENTITY_INSERT [HR].[VPNs] ON 

INSERT [HR].[VPNs] ([VPNID], [UserTypeID], [UserID], [DepartmentID], [Username], [Password], [VPNDescription]) VALUES (1, 1, 12, 1, N'a', N'', N'')
SET IDENTITY_INSERT [HR].[VPNs] OFF
SET IDENTITY_INSERT [HR].[WebServiceAccount] ON 

INSERT [HR].[WebServiceAccount] ([AccountID], [Password], [Username], [Status]) VALUES (1, N'202CB962AC59075B964B07152D234B70', N'webacount', 0)
INSERT [HR].[WebServiceAccount] ([AccountID], [Password], [Username], [Status]) VALUES (2, N'202CB962AC59075B964B07152D234B70', N'tp', 0)
SET IDENTITY_INSERT [HR].[WebServiceAccount] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[1] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EduTendencies (HR)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 230
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EduFields (HR)"
            Begin Extent = 
               Top = 10
               Left = 300
               Bottom = 159
               Right = 460
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1200
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VEduTendencies'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VEduTendencies'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EmailContacts (HR)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 209
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EmailTypes (HR)"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 136
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VEmailContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VEmailContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[53] 4[8] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 2
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employees (HR)"
            Begin Extent = 
               Top = 17
               Left = 306
               Bottom = 206
               Right = 478
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "Departments (HR)"
            Begin Extent = 
               Top = 143
               Left = 673
               Bottom = 239
               Right = 848
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Roles (HR)"
            Begin Extent = 
               Top = 156
               Left = 41
               Bottom = 252
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Lecturers (HR)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 216
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Faculties (HR)"
            Begin Extent = 
               Top = 6
               Left = 238
               Bottom = 95
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EduFields (HR)"
            Begin Extent = 
               Top = 6
               Left = 436
               Bottom = 95
               Right = 596
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EduTendencies (HR)"
            Begin Extent = 
               Top = 6
               Left = 634
               Bottom = 110
               Right = 794
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VLecturers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VLecturers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Students (HR)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 216
               Right = 200
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "Faculties (HR)"
            Begin Extent = 
               Top = 6
               Left = 238
               Bottom = 95
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EduLevels (HR)"
            Begin Extent = 
               Top = 6
               Left = 436
               Bottom = 95
               Right = 596
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EduFields (HR)"
            Begin Extent = 
               Top = 6
               Left = 634
               Bottom = 95
               Right = 794
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EduTendencies (HR)"
            Begin Extent = 
               Top = 6
               Left = 832
               Bottom = 110
               Right = 992
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VStudents'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VStudents'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VStudents'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TelContacts (HR)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 180
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TelTypes (HR)"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 155
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTelContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VTelContacts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "VPNS (HR)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 210
               Right = 210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Departments (HR)"
            Begin Extent = 
               Top = 6
               Left = 248
               Bottom = 101
               Right = 423
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VVPNs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VVPNs'
GO
