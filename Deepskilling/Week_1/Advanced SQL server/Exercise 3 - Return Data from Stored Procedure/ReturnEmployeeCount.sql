CREATE PROCEDURE sp_GetEmployeeCount
    @DepartmentID INT
AS
BEGIN
    SELECT
        COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;