--Trigger Query
CREATE TRIGGER tr_AfterChangeProductTable
ON Products
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TypeChange NVARCHAR(10);

    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        SET @TypeChange = 'INSERT';

        INSERT INTO MonitorEvents (MonitorEventId, TableId, TableName, TypeChange, CreateDate)
        SELECT NEWID(), ProductId, 'Products', @TypeChange, GETDATE()
        FROM inserted;
    END;

    IF EXISTS(SELECT * FROM deleted)
    BEGIN
        IF @TypeChange IS NULL OR @TypeChange = 'INSERT'
        BEGIN
            SET @TypeChange = 'DELETE';

            INSERT INTO MonitorEvents (MonitorEventId, TableId, TableName, TypeChange, CreateDate)
            SELECT NEWID(), ProductId, 'Products', @TypeChange, GETDATE()
            FROM deleted;
        END
        ELSE
        BEGIN --UPDATE đang bị duplicate ROW trong MONITOREVENTS table
            INSERT INTO MonitorEvents (MonitorEventId, TableId, TableName, TypeChange, CreateDate)
            SELECT NEWID(), d.ProductId, 'Products', 'UPDATE', GETDATE()
            FROM deleted d
            INNER JOIN inserted i ON d.ProductId = i.ProductId;
        END;
    END;
END;

--Category Queries
INSERT INTO Categories (CategoryID, CategoryName, Description) 
VALUES (NEWID(), N'Máy tính bảng', N'Máy tính bảng');

INSERT INTO Categories (CategoryID, CategoryName, Description) 
VALUES (NEWID(), N'Điện thoại', N'Điện thoại');

--Product Queries
INSERT INTO Products (ProductId, ProductName, UnitPrice, Description, CategoryId) 
VALUES (NEWID(), 'Ipad Gen 9', 900000, 'Ipad', '620A05BC-0331-473B-8036-EA41F2852546');

INSERT INTO Products (ProductId, ProductName, UnitPrice, Description, CategoryId) 
VALUES (NEWID(), 'Iphone 11', 1000000, 'Iphone', '23BB583F-2235-43DC-8EDA-C5532DC1FE45');

UPDATE Products
SET UnitPrice = 1200000
WHERE ProductId = 'A686C5E8-8AC7-4E7D-9C47-4E119A27C1A2';

DELETE FROM Products WHERE ProductId = '3BD3FA6F-37D0-44FA-8594-5BC30D3D7678'
