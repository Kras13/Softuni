CREATE OR ALTER PROCEDURE usp_PlaceOrder @jobID INT, @partSerialNumber VARCHAR(50), @quantity INT
AS
BEGIN
    IF (@quantity <= 0)
    BEGIN
        THROW 50012, 'Part quantity must be more than zero!', 1
    END
 
    IF((SELECT [Status] FROM [Jobs]
        WHERE [JobId] = @jobID) = 'Finished')
    BEGIN
        THROW 50011, 'This job is not active!', 1
    END
 
    DECLARE @jobIdDb INT = (
                            SELECT [JobId] FROM [Jobs]
                            WHERE [JobId] = @jobID
                           )
    IF (@jobIdDb IS NULL)
    BEGIN
        THROW 50013, 'Job not found!', 1
    END
 
    DECLARE @partId INT = (
                            SELECT [PartId] FROM [Parts]
                            WHERE [SerialNumber] = @partSerialNumber
                          )
    IF (@partId IS NULL)
    BEGIN
        THROW 50014, 'Part not found!', 1
    END
 
    ---There is no any orders for given @jobId and we should create a new order in all cases
    IF ((SELECT [OrderId] FROM [Orders]
        WHERE [JobId] = @jobID AND [IssueDate] IS NULL) IS NULL)
    BEGIN
        INSERT INTO [Orders]([JobId], [IssueDate], [Delivered])
        VALUES
        (@jobID, NULL, 0)
    END
 
    ---It returns the OrderId of newly created or alredy existing order
    DECLARE @orderId INT = (SELECT [OrderId] FROM [Orders]
                            WHERE [JobId] = @jobID AND [IssueDate] IS NULL
                           )
 
    DECLARE @orderedPartQuantity INT = (SELECT [Quantity] FROM [OrderParts]
                                        WHERE [OrderId] = @orderId AND [PartId] = @partId
                                       )
    ---There is no order for the given @partId and @orderId. We should order it with given @quantity
    IF (@orderedPartQuantity IS NULL)
    BEGIN
        INSERT INTO [OrderParts]([OrderId], [PartId], [Quantity])
        VALUES
        (@orderId, @partId, @quantity)
    END
    ELSE
    BEGIN
        UPDATE [OrderParts]
        SET [Quantity] += @quantity
        WHERE [OrderId] = @orderId AND [PartId] = @partId
    END
END