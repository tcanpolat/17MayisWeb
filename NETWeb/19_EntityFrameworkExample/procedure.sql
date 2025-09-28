create procedure GetStudentsByDepartment @Department varchar(50)
as
begin
	select * from Students where Department = @Department
end