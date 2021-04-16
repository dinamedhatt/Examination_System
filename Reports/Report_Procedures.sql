alter proc coursesTopics @Course_ID int
as
select Topic_name from Topics where Crs_Id = (@Course_ID)

-----------------------------------
create proc ExamQuestions @Exam_Number int
as
select Q_Desc from Questions Q , St_Answer A
where Q.Q_Id = A.Q_Id AND A.Exam_Id = (@Exam_Number)

-------------------------------------
create proc InstructorCourses @Instructor_ID int
as
select Crs_Name,count(St_Id) as Student_Number from Courses C ,Student_Crs SC ,Inst_Crs IC
where C.Crs_Id=IC.Crs_Id AND IC.Crs_Id=SC.Crs_Id AND IC.Ins_Id = (@Instructor_ID)
group by Crs_Name

-------------------------------------
create proc studentsGrades @Student_ID int
as
select concat(St_Fname,' ',St_Lname) as St_FullName , Crs_name, Crs_Grade from Student S ,Student_Crs SC,Courses C
where S.St_Id = SC.St_Id AND C.Crs_Id = SC.Crs_Id AND S.St_Id = (@Student_ID)

-------------------------------------
create proc studentAnswers @Student_ID int , @Exam_Number int
as
select Q.Q_Desc, A.St_Ans from St_Answer A , Questions Q
where Q.Q_Id = A.Q_Id AND A.Exam_Id = (@Exam_Number) AND A.St_Id = (@Student_ID)

---------------------------------------
alter proc departmentStudents @Department int
as 
Select St_Fname+' '+St_Lname as Full_Name, St_Age, St_Address, Dept_id from Student where Dept_id = (@Department)