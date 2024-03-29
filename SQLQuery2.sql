CREATE PROCEDURE GetStudentDetails
    @StudentID INT
AS
BEGIN
    SELECT FullName, Age
    FROM Students
    WHERE StudentID = @StudentID;
END

--CRUD OPERATION STORED PROCEDURE--
--CREATE---

CREATE PROCEDURE INSERTSTUDENT
@FullName nvarchar(100),
@Age int
as
begin
INSERT INTO Students(FullName,Age)
VALUES (@FullName,@Age);
END


---UPDATE---
CREATE PROCEDURE UPDATESTUDENT
@StudentID INT,
@FullName nvarchar(100),
@Age int
as
begin
UPDATE Students
set FullName = @FullName,
Age=@Age
where StudentID=@StudentID;
end

---DELETE---
CREATE PROCEDURE DELETESTUDENT
@StudentID  INT
AS
BEGIN
DELETE FROM Students
WHERE StudentID=@StudentID;
END