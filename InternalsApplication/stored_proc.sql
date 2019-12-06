USE [InternalsDatabase]
GO
/****** Object:  Trigger [dbo].[CalculateReport]    Script Date: 06-12-2019 00:01:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[CalculateReport]
on [dbo].[Script]
after insert
as
begin
	declare @USN nvarchar(255)
	declare @reportCount int = 0
	declare @TeacherID nvarchar(255)
	declare @Dept_No int
	declare @subjectCode nvarchar(255)
	declare @scriptID int
	declare @IA1 int
	declare @IA2 int
	declare @IA3 int
	declare @total int
	declare @percentage float

	select @USN = USN from inserted 
	select @TeacherID = Teacher_ID from inserted 
	select @Dept_No = Dept_No from inserted
	select @subjectCode = Subject_Code from inserted
	select @scriptID = Script_ID from inserted
	select @IA1 = IA1 from inserted
	select @IA2 = IA2 from inserted
	select @IA3 = IA3 from inserted
	
	insert into dbo.Report values (@reportCount,@IA1 + @IA2 + @IA3 ,((@IA1+@IA2+@IA3)/150)*100 ,@USN,@TeacherID,@Dept_No,@subjectCode,@scriptID);
end