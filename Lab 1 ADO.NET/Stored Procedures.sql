CREATE PROCEDURE StudentsBySurnameRising
    @LastName INT
AS
BEGIN   
    SELECT * FROM Students 
    ORDER BY LastName
END;



