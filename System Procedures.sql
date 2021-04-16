create proc StudentLogin 
(@ID int , @PW varchar(8))
as
select Count(*) from Student where St_Id = @ID and Password = @PW

create proc InstructorLogin 
(@ID int , @PW varchar(8))
as
select Count(*) from Instructor where Ins_Id = @ID and Ins_Password = @PW

-----------------------------------------------

 alter proc InstructorCrs @InsID int
 as
 select C.Crs_Id, Crs_Name from Courses C , Inst_Crs IC
 where C.Crs_Id = IC.Crs_Id AND IC.Ins_Id = @InsID

-----------------------------------------------

alter proc AnswerCorrection @SID int ,@CID int
as
Update St_Answer 
set Ans_Grade = Q.Q_Grade 
from St_Answer SA inner join Questions Q 
on SA.Q_Id = Q.Q_Id 
where SA.St_Ans = Q.Q_Ans 

update Student_Crs set Crs_Grade = 
(select Sum(Ans_Grade) as sumofQ 
from St_Answer SA, Questions Q 
where SA.St_Id=St_Id and Q.Crs_Id = Crs_Id and Q.Q_Id = SA.Q_Id
AND St_Id=@SID and Crs_Id=@CID 
)
where St_Id=@SID and Crs_Id=@CID 


-------------------------------------------------------

create proc ExamCreate @examDuration int , @CrsID int
with encryption
as
insert into Exam(Ex_duration,Ex_startTime,Crs_Id)values(@examDuration, GETDATE(), @CrsID)


select * from Exam

--to return identity to get started from 1 (if deleted not truncated)
--DBCC CHECKIDENT ('[Exam]', RESEED, 0);

----------------------------------------------

alter proc studentCourses @StID int
as
select distinct S.St_Id, C.Crs_Id,  Crs_Name from Student S, Courses C, Student_Crs SC,Exam E
where S.St_Id = SC.St_Id AND C.Crs_Id = SC.Crs_Id 
AND E.Crs_Id = C.Crs_Id 
AND not exists (
select St_Id from Student_Crs where St_Id=S.St_Id AND Crs_Id=C.Crs_Id AND Crs_Grade!=0
)
AND S.St_Id=@StID


--------------------------------------------

create proc ExamGeneration @SID int, @CID int
with encryption
as
declare @EID int =(
select top(1) Exam_Id from Exam
where Crs_Id = @CID
order by NEWID() )

insert into St_Answer (Q_Id,St_Id,Exam_Id)
SELECT * 
FROM
(
SELECT TOP(5) Q_Id , St_Id , Exam_Id
FROM Questions Q, Student S, Exam E
where Q_Type = 'MCQ' AND Q.Crs_Id=@CID
AND S.St_Id = @SID AND E.Exam_Id = @EID
ORDER BY NEWID()
) A
UNION ALL
SELECT * FROM
(
SELECT TOP(5) Q_Id ,St_Id, Exam_Id
FROM Questions Q, Student S ,Exam E
where Q_Type = 'T/F' AND Q.Crs_Id=@CID
AND S.St_Id = @SID AND E.Exam_Id = @EID
ORDER BY NEWID()
) B


------------------------------------------------
alter proc questionChoices @QID int
as
select Choice, C.Q_Id from Q_Choices C, Questions Q, St_Answer SA
where Q.Q_Id=C.Q_Id AND SA.Q_Id=C.Q_Id AND C.Q_Id=@QID
group by C.Q_Id,Choice 


-----------------------------------------------
alter proc getQuestionList @SID int, @CID int
as
select Q.Q_Id, Q_Desc from Questions Q , St_Answer SA
where  Q.Q_Id = SA.Q_Id AND SA.St_Id=@SID AND Q.Crs_Id=@CID
order by SA.Q_Id

select Choice from Questions Q ,Q_Choices C, St_Answer SA
where  Q.Q_Id = SA.Q_Id AND C.Q_Id = Q.Q_Id
order by Q.Q_Id


--------------------------------------------------------
alter proc answerQuestion(@QID int, @SID int, @CID int, @Ans varchar(50))
as
update St_Answer set St_Ans=@Ans where Q_Id=@QID 
and Q_Id=(select Q_Id from Questions where Q_Id =@QID and Crs_Id=@CID)
and St_Id=@SID


--------------------------------------------------------
alter proc getCrsGrade @SID int, @CID int
as
select Crs_Grade from Student_Crs where St_Id=@SID AND Crs_Id=@CID

-------------------------------------------------------

alter proc getExamDuration @CID int
as
select Ex_duration,Crs_Id from Exam where Crs_Id=@CID